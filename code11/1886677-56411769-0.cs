    using System;
    using System.Diagnostics;
    
    namespace BaysDurhamShuffling
    {
        public class BaysDurhamRNG
        {
            public int[] _table;
            public int   _xnext;
    
            public Random _rng = null;
    
            public BaysDurhamRNG(int n, int seed = 312357) {
                Debug.Assert(n > 1);
    
                _rng = new Random(seed);
                _table = new int [n];
                for(int k = 0; k != n; ++k) {
                    _table[k] = _rng.Next();
                }
                _xnext = _rng.Next();
            }
    
            public int next() {
                var x = _xnext; // store return value
    
                var j  = _xnext % _table.Length; // form the index j into the table
                _xnext = _table[j];              // get jth element of table and to copy it to the output stream on next call
                _table[j] = _rng.Next();         // replace jth element of table with next random value from input stream
    
                return x; // return what was stored in next value
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var rng = new BaysDurhamRNG (16, 12345);
    
                for(int k = 0; k != 30; ++k) {
                    var x = rng.next();
                    Console.WriteLine($"RV = {x}");
                }
            }
        }
    }
