    using System;
    using System.IO;
    public class ChunkInfo
    {
        private byte[] m_Header;
        private long m_Length;
        private long m_OffSet;
        public ChunkInfo(string Header)
        {
            m_Header = new byte[Header.Length];
            for (int i = 0; i <= m_Header.GetUpperBound(0); i++)
            {
                m_Header[i] = (byte)Header[i];
            }
        }
        public ChunkInfo(byte[] Header)
        {
            m_Header = Header;
        }
        public void Read(BinaryReader br)
        {
            m_OffSet = SearchOffset(br);
            if (m_OffSet >= 0)
            {
                br.BaseStream.Position = m_OffSet + m_Header.Length;
                m_Length = br.ReadInt32();
            }
        }
        public void Write(BinaryWriter bw)
        {
            bw.Write(m_Header);
            bw.Write(m_Length);
        }
        public long Length
        {
            get { return m_Length; }
        }
        public long OffSet
        {
            get { return m_OffSet; }
        }
        private long SearchOffset(BinaryReader br)
        {
            byte[] haystack = null;
            bool found = false;
            long offset = 0;
            long basepos = 0;
            int hlength = 260;
            long basepos_grow = hlength - m_Header.Length;
            while (!(found || (basepos >= br.BaseStream.Length)))
            {
                br.BaseStream.Position = basepos;
                haystack = br.ReadBytes(hlength);
                offset = BoyerMooreHorspool.find(haystack, m_Header);
                found = offset >= 0;
                if (found)
                {
                    offset += basepos;
                    break; 
                }
                else
                {
                    basepos += basepos_grow;
                }
            }
            return offset;
        }
    }
    public static class BoyerMooreHorspool
    {
        //detects a needle in the haystack
        const int UBYTE_MAX = 255;
        static int[] bad_char_skip4 = new int[UBYTE_MAX + 3];
        static int[] bad_char_skip8 = new int[UBYTE_MAX + 3];
        static bool IsInitialized = false;
        public static void init()
        {
            //little optimization for needles with length 4 or 8
            for (int i = 0; i <= UBYTE_MAX + 2; i++)
            {
                bad_char_skip4[i] = 4;
                bad_char_skip8[i] = 8;
            }
            IsInitialized = true;
        }
        public static int find(byte[] haystack, byte[] needle, int start = 0)
        {
            if (!IsInitialized) init();
            int i_n = 0;
            //needle index
            int n_n = needle.Length;
            int[] bad_char_skip = null;
            switch (n_n)
            {
                case 4:
                    bad_char_skip = bad_char_skip4;
                    break;
                case 8:
                    bad_char_skip = bad_char_skip8;
                    break;
                default:
                    bad_char_skip = new int[UBYTE_MAX + 3];
                    for (i_n = 0; i_n <= UBYTE_MAX + 2; i_n++)
                    {
                        bad_char_skip[i_n] = n_n;
                    }
    
                    break;
            }
            int ifind = -1;
            //if not found then return - 1
            int i_h = start;
            //haystack index
            int n_h = haystack.Length;
            if (n_n > n_h)
                throw new ArgumentOutOfRangeException("needle", "needle is to long");
            int last = n_n - 1;
            for (i_n = 0; i_n <= last - 1; i_n++)
            {
                bad_char_skip[needle[i_n]] = last - i_n;
            }
            byte bcs = 0;
            int bhs = 0;
            while ((n_h - start) >= n_n)
            {
                i_n = last;
                while (haystack[i_h + i_n] == needle[i_n])
                {
                    i_n -= 1;
                    if (i_n == 0)
                    {
                        ifind = i_h;
                        break; 
                    }
                }
                bhs = haystack[i_h + last];
                bcs = (byte)(bad_char_skip[bhs]);
                n_h -= bcs;
                i_h += bcs;
            }
            return ifind;
        }
    }
