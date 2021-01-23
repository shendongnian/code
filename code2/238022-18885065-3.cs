      using System;
      using System.Collections;
      using System.Collections.Generic;
      using System.Linq;
      using System.Threading;
      using System.Threading.Tasks;
      class UltimatePrimesSoE : IEnumerable<ulong> {
        #region const and static readonly field's, private struct's and classes
        //one can get single threaded performance by setting NUMPRCSPCS = 1
        static readonly uint NUMPRCSPCS = (uint)Environment.ProcessorCount + 1;
        //the L1CACHEPOW can not be less than 14 and is usually the two raised to the power of the L1 or L2 cache
        const int L1CACHEPOW = 14, L1CACHESZ = (1 << L1CACHEPOW), MXPGSZ = L1CACHESZ / 2; //for buffer ushort[]
        const uint CHNKSZ = 17; //this times BWHLWRDS (below) times two should not be bigger than the L2 cache in bytes
        //the 2,3,57 factorial wheel increment pattern, (sum) 48 elements long, starting at prime 19 position
        static readonly byte[] WHLPTRN = { 2,3,1,3,2,1,2,3,3,1,3,2,1,3,2,3,4,2,1,2,1,2,4,3,
                                           2,3,1,2,3,1,3,3,2,1,2,3,1,3,2,1,2,1,5,1,5,1,2,1 }; const uint FSTCP = 11;
        static readonly byte[] WHLPOS; static readonly byte[] WHLNDX; //look up wheel position from index and vice versa
        static readonly byte[] WHLRNDUP; //to look up wheel rounded up index positon values, allow for overflow in size
        static readonly uint WCRC = WHLPTRN.Aggregate(0u, (acc, n) => acc + n); //small wheel circumference for odd numbers
        static readonly uint WHTS = (uint)WHLPTRN.Length; static readonly uint WPC = WHTS >> 4; //number of wheel candidates
        static readonly byte[] BWHLPRMS = { 2,3,5,7,11,13,17 }; const uint FSTBP = 19; //big wheel primes, following prime
        //the big wheel circumference expressed in number of 16 bit words as in a minimum bit buffer size
        static readonly uint BWHLWRDS = BWHLPRMS.Aggregate(1u, (acc, p) => acc * p) / 2 / WCRC * WHTS / 16;
        //page size and range as developed from the above
        static readonly uint PGSZ = MXPGSZ / BWHLWRDS * BWHLWRDS; static readonly uint PGRNG = PGSZ * 16 / WHTS * WCRC;
        //buffer size (multiple chunks) as produced from the above
        static readonly uint BFSZ = CHNKSZ * PGSZ, BFRNG = CHNKSZ * PGRNG; //number of uints even number of caches in chunk
        static readonly ushort[] MCPY; //a Master Copy page used to hold the lower base primes preculled version of the page
        struct Wst { public ushort msk; public byte mlt; public byte xtr; public ushort nxt; }
        static readonly byte[] PRLUT; /*Wheel Index Look Up Table */ static readonly Wst[] WSLUT; //Wheel State Look Up Table
        static readonly byte[] CLUT; // a Counting Look Up Table for very fast counting of primes
        class Bpa {	//very efficient auto-resizing thread-safe read-only indexer class to hold the base primes array
          byte[] sa = new byte[0]; uint lwi = 0, lpd = 0; object lck = new object();
          public uint this[uint i] {
            get {
              if (i >= this.sa.Length) lock (this.lck) {
                  var lngth = this.sa.Length; while (i >= lngth) {
                    var bf = (ushort[])MCPY.Clone(); if (lngth == 0) {
                      for (uint bi = 0, wi = 0, w = 0, msk = 0x8000, v = 0; w < bf.Length;
                          bi += WHLPTRN[wi++], wi = (wi >= WHTS) ? 0 : wi) {
                        if (msk >= 0x8000) { msk = 1; v = bf[w++]; } else msk <<= 1;
                        if ((v & msk) == 0) {
                          var p = FSTBP + (bi + bi); var k = (p * p - FSTBP) >> 1;
                          if (k >= PGRNG) break; var pd = p / WCRC; var kd = k / WCRC; var kn = WHLNDX[k - kd * WCRC];
                          for (uint wrd = kd * WPC + (uint)(kn >> 4), ndx = wi * WHTS + kn; wrd < bf.Length; ) {
                            var st = WSLUT[ndx]; bf[wrd] |= st.msk; wrd += st.mlt * pd + st.xtr; ndx = st.nxt;
                          }
                        }
                      }
                    }
                    else { this.lwi += PGRNG; cullbf(this.lwi, bf); }
                    var c = count(PGRNG, bf); var na = new byte[lngth + c]; sa.CopyTo(na, 0);
                    for (uint p = FSTBP + (this.lwi << 1), wi = 0, w = 0, msk = 0x8000, v = 0;
                        lngth < na.Length; p += (uint)(WHLPTRN[wi++] << 1), wi = (wi >= WHTS) ? 0 : wi) {
                      if (msk >= 0x8000) { msk = 1; v = bf[w++]; } else msk <<= 1; if ((v & msk) == 0) {
                        var pd = p / WCRC; na[lngth++] = (byte)(((pd - this.lpd) << 6) + wi); this.lpd = pd;
                      }
                    } this.sa = na;
                  }
                } return this.sa[i];
            }
          }
        }
        static readonly Bpa baseprms = new Bpa(); //the base primes array using the above class
        struct PrcsSpc { public Task tsk; public ushort[] buf; } //used for multi-threading buffer array processing
        #endregion
        #region private static methods
        static int count(uint bitlim, ushort[] buf) { //very fast counting method using the CLUT look up table
          if (bitlim < BFRNG) {
            var addr = (bitlim - 1) / WCRC; var bit = WHLNDX[bitlim - addr * WCRC] - 1; addr *= WPC;
            for (var i = 0; i < 3; ++i) buf[addr++] |= (ushort)((unchecked((ulong)-2) << bit) >> (i << 4));
          }
          var acc = 0; for (uint i = 0, w = 0; i < bitlim; i += WCRC)
            acc += CLUT[buf[w++]] + CLUT[buf[w++]] + CLUT[buf[w++]]; return acc;
        }
        static void cullbf(ulong lwi, ushort[] b) { //fast buffer segment culling method using a Wheel State Look Up Table
          ulong nlwi = lwi;
          for (var i = 0u; i < b.Length; nlwi += PGRNG, i += PGSZ) MCPY.CopyTo(b, i); //copy preculled lower base primes.
          for (uint i = 0, pd = 0; ; ++i) {
            pd += (uint)baseprms[i] >> 6;
            var wi = baseprms[i] & 0x3Fu; var wp = (uint)WHLPOS[wi]; var p = pd * WCRC + PRLUT[wi];
            var k = ((ulong)p * (ulong)p - FSTBP) >> 1;
            if (k >= nlwi) break; if (k < lwi) {
              k = (lwi - k) % (WCRC * p);
              if (k != 0) {
                var nwp = wp + (uint)((k + p - 1) / p); k = (WHLRNDUP[nwp] - wp) * p - k;
              }
            }
            else k -= lwi; var kd = k / WCRC; var kn = WHLNDX[k - kd * WCRC];
            for (uint wrd = (uint)kd * WPC + (uint)(kn >> 4), ndx = wi * WHTS + kn; wrd < b.Length; ) {
              var st = WSLUT[ndx]; b[wrd] |= st.msk; wrd += st.mlt * pd + st.xtr; ndx = st.nxt;
            }
          }
        }
        static Task cullbftsk(ulong lwi, ushort[] b, Action<ushort[]> f) { // forms a task of the cull buffer operaion
          return Task.Factory.StartNew(() => { cullbf(lwi, b); f(b); });
        }
        //iterates the action over each page up to the page including the top_number,
        //making an adjustment to the top limit for the last page.
        //this method works for non-dependent actions that can be executed in any order.
        static void IterateTo(ulong top_number, Action<ulong, uint, ushort[]> actn) {
          PrcsSpc[] ps = new PrcsSpc[NUMPRCSPCS]; for (var s = 0u; s < NUMPRCSPCS; ++s) ps[s] = new PrcsSpc {
            buf = new ushort[BFSZ],
            tsk = Task.Factory.StartNew(() => { })
          };
          var topndx = (top_number - FSTBP) >> 1; for (ulong ndx = 0; ndx <= topndx; ) {
            ps[0].tsk.Wait(); var buf = ps[0].buf; for (var s = 0u; s < NUMPRCSPCS - 1; ++s) ps[s] = ps[s + 1];
            var lowi = ndx; var nxtndx = ndx + BFRNG; var lim = topndx < nxtndx ? (uint)(topndx - ndx + 1) : BFRNG;
            ps[NUMPRCSPCS - 1] = new PrcsSpc { buf = buf, tsk = cullbftsk(ndx, buf, (b) => actn(lowi, lim, b)) };
            ndx = nxtndx;
          } for (var s = 0u; s < NUMPRCSPCS; ++s) ps[s].tsk.Wait();
        }
        //iterates the predicate over each page up to the page where the predicate paramenter returns true,
        //this method works for dependent operations that need to be executed in increasing order.
        //it is somewhat slower than the above as the predicate function is executed outside the task.
        static void IterateUntil(Func<ulong, ushort[], bool> prdct) {
          PrcsSpc[] ps = new PrcsSpc[NUMPRCSPCS];
          for (var s = 0u; s < NUMPRCSPCS; ++s) {
            var buf = new ushort[BFSZ];
            ps[s] = new PrcsSpc { buf = buf, tsk = cullbftsk(s * BFRNG, buf, (bfr) => { }) };
          }
          for (var ndx = 0UL; ; ndx += BFRNG) {
            ps[0].tsk.Wait(); var buf = ps[0].buf; var lowi = ndx; if (prdct(lowi, buf)) break;
            for (var s = 0u; s < NUMPRCSPCS - 1; ++s) ps[s] = ps[s + 1];
            ps[NUMPRCSPCS - 1] = new PrcsSpc {
              buf = buf,
              tsk = cullbftsk(ndx + NUMPRCSPCS * BFRNG, buf, (bfr) => { })
            };
          }
        }
        #endregion
        #region initialization
        /// <summary>
        /// the static constructor is used to initialize the static readonly arrays.
        /// </summary>
        static UltimatePrimesSoE() {
          WHLPOS = new byte[WHLPTRN.Length + 1]; //to look up wheel position index from wheel index
          for (byte i = 0, acc = 0; i < WHLPTRN.Length; ++i) { acc += WHLPTRN[i]; WHLPOS[i + 1] = acc; }
          WHLNDX = new byte[WCRC + 1]; for (byte i = 1; i < WHLPOS.Length; ++i) {
            for (byte j = (byte)(WHLPOS[i - 1] + 1); j <= WHLPOS[i]; ++j) WHLNDX[j] = i;
          }
          WHLRNDUP = new byte[WCRC * 2]; for (byte i = 1; i < WHLRNDUP.Length; ++i) {
            if (i > WCRC) WHLRNDUP[i] = (byte)(WCRC + WHLPOS[WHLNDX[i - WCRC]]); else WHLRNDUP[i] = WHLPOS[WHLNDX[i]];
          }
          Func<ushort, int> nmbts = (v) => { var acc = 0; while (v != 0) { acc += (int)v & 1; v >>= 1; } return acc; };
          CLUT = new byte[1 << 16]; for (var i = 0; i < CLUT.Length; ++i) CLUT[i] = (byte)nmbts((ushort)(i ^ -1));
          PRLUT = new byte[WHTS]; for (var i = 0; i < PRLUT.Length; ++i) {
            var t = (uint)(WHLPOS[i] * 2) + FSTBP; if (t >= WCRC) t -= WCRC; if (t >= WCRC) t -= WCRC; PRLUT[i] = (byte)t;
          }
          WSLUT = new Wst[WHTS * WHTS]; for (var x = 0u; x < WHTS; ++x) {
            var p = FSTBP + 2u * WHLPOS[x]; var pr = p % WCRC;
            for (uint y = 0, pos = (p * p - FSTBP) / 2; y < WHTS; ++y) {
              var m = WHLPTRN[(x + y) % WHTS];
              pos %= WCRC; var posn = WHLNDX[pos]; pos += m * pr; var nposd = pos / WCRC; var nposn = WHLNDX[pos - nposd * WCRC];
              WSLUT[x * WHTS + posn] = new Wst {
                msk = (ushort)(1 << (int)(posn & 0xF)),
                mlt = (byte)(m * WPC),
                xtr = (byte)(WPC * nposd + (nposn >> 4) - (posn >> 4)),
                nxt = (ushort)(WHTS * x + nposn)
              };
            }
          }
          MCPY = new ushort[PGSZ]; foreach (var lp in BWHLPRMS.SkipWhile(p => p < FSTCP)) {
            var p = (uint)lp;
            var k = (p * p - FSTBP) >> 1; var pd = p / WCRC; var kd = k / WCRC; var kn = WHLNDX[k - kd * WCRC];
            for (uint w = kd * WPC + (uint)(kn >> 4), ndx = WHLNDX[(2 * WCRC + p - FSTBP) / 2] * WHTS + kn; w < MCPY.Length; ) {
              var st = WSLUT[ndx]; MCPY[w] |= st.msk; w += st.mlt * pd + st.xtr; ndx = st.nxt;
            }
          }
        }
        #endregion
        #region public class
        // this class implements the enumeration (IEnumerator).
        //    it works by farming out tasks culling pages, which it then processes in order by
        //    enumerating the found primes as recognized by the remaining non-composite bits
        //    in the cull page buffers.
        class nmrtr : IEnumerator<ulong>, IEnumerator, IDisposable {
          PrcsSpc[] ps = new PrcsSpc[NUMPRCSPCS]; ushort[] buf;
          public nmrtr() {
            for (var s = 0u; s < NUMPRCSPCS; ++s) ps[s] = new PrcsSpc { buf = new ushort[BFSZ] };
            for (var s = 1u; s < NUMPRCSPCS; ++s) {
              ps[s].tsk = cullbftsk((s - 1u) * BFRNG, ps[s].buf, (bfr) => { });
            } buf = ps[0].buf;
          }
          ulong _curr, i = (ulong)-WHLPTRN[WHTS - 1]; int b = -BWHLPRMS.Length - 1; uint wi = WHTS - 1; ushort v, msk = 0;
          public ulong Current { get { return this._curr; } } object IEnumerator.Current { get { return this._curr; } }
          public bool MoveNext() {
            if (b < 0) {
              if (b == -1) b += buf.Length; //no yield!!! so automatically comes around again
              else { this._curr = (ulong)BWHLPRMS[BWHLPRMS.Length + (++b)]; return true; }
            }
            do {
              i += WHLPTRN[wi++]; if (wi >= WHTS) wi = 0; if ((this.msk <<= 1) == 0) {
                if (++b >= BFSZ) {
                  b = 0; for (var prc = 0; prc < NUMPRCSPCS - 1; ++prc) ps[prc] = ps[prc + 1];
                  ps[NUMPRCSPCS - 1u].buf = buf;
                  ps[NUMPRCSPCS - 1u].tsk = cullbftsk(i + (NUMPRCSPCS - 1u) * BFRNG, buf, (bfr) => { });
                  ps[0].tsk.Wait(); buf = ps[0].buf;
                } v = buf[b]; this.msk = 1;
              }
            }
            while ((v & msk) != 0u); _curr = FSTBP + i + i; return true;
          }
          public void Reset() { throw new Exception("Primes enumeration reset not implemented!!!"); }
          public void Dispose() { }
        }
        #endregion
        #region public instance method and associated sub private method
        /// <summary>
        /// Gets the enumerator for the primes.
        /// </summary>
        /// <returns>The enumerator of the primes.</returns>
        public IEnumerator<ulong> GetEnumerator() { return new nmrtr(); }
        /// <summary>
        /// Gets the enumerator for the primes.
        /// </summary>
        /// <returns>The enumerator of the primes.</returns>
        IEnumerator IEnumerable.GetEnumerator() { return new nmrtr(); }
        #endregion
        #region public static methods
        /// <summary>
        /// Gets the count of primes up the number, inclusively.
        /// </summary>
        /// <param name="top_number">The ulong top number to check for prime.</param>
        /// <returns>The long number of primes found.</returns>
        public static long CountTo(ulong top_number) {
          if (top_number < FSTBP) return BWHLPRMS.TakeWhile(p => p <= top_number).Count();
          var cnt = (long)BWHLPRMS.Length;
          IterateTo(top_number, (lowi, lim, b) => { Interlocked.Add(ref cnt, count(lim, b)); }); return cnt;
        }
        /// <summary>
        /// Gets the sum of the primes up the number, inclusively.
        /// </summary>
        /// <param name="top_number">The uint top number to check for prime.</param>
        /// <returns>The ulong sum of all the primes found.</returns>
        public static ulong SumTo(uint top_number) {
          if (top_number < FSTBP) return (ulong)BWHLPRMS.TakeWhile(p => p <= top_number).Aggregate(0u, (acc, p) => acc += p);
          var sum = (long)BWHLPRMS.Aggregate(0u, (acc, p) => acc += p);
          Func<ulong, uint, ushort[], long> sumbf = (lowi, bitlim, buf) => {
            var acc = 0L; for (uint i = 0, wi = 0, msk = 0x8000, w = 0, v = 0; i < bitlim;
                i += WHLPTRN[wi++], wi = wi >= WHTS ? 0 : wi) {
              if (msk >= 0x8000) { msk = 1; v = buf[w++]; } else msk <<= 1;
              if ((v & msk) == 0) acc += (long)(FSTBP + ((lowi + i) << 1));
            } return acc;
          };
          IterateTo(top_number, (pos, lim, b) => { Interlocked.Add(ref sum, sumbf(pos, lim, b)); }); return (ulong)sum;
        }
        /// <summary>
        /// Gets the prime number at the zero based index number given.
        /// </summary>
        /// <param name="index">The long zero-based index number for the prime.</param>
        /// <returns>The ulong prime found at the given index.</returns>
        public static ulong ElementAt(long index) {
          if (index < BWHLPRMS.Length) return (ulong)BWHLPRMS.ElementAt((int)index);
          long cnt = BWHLPRMS.Length; var ndx = 0UL; var cycl = 0u; var bit = 0u; IterateUntil((lwi, bfr) => {
            var c = count(BFRNG, bfr); if ((cnt += c) < index) return false; ndx = lwi; cnt -= c; c = 0;
            do { var w = cycl++ * WPC; c = CLUT[bfr[w++]] + CLUT[bfr[w++]] + CLUT[bfr[w]]; cnt += c; } while (cnt < index);
            cnt -= c; var y = (--cycl) * WPC; ulong v = ((ulong)bfr[y + 2] << 32) + ((ulong)bfr[y + 1] << 16) + bfr[y];
            do { if ((v & (1UL << ((int)bit++))) == 0) ++cnt; } while (cnt <= index); --bit; return true;
          }); return FSTBP + ((ndx + cycl * WCRC + WHLPOS[bit]) << 1);
        }
        #endregion
      }
