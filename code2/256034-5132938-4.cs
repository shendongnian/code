        public int FindBytes(byte[] src, byte[] find)
        {
            int index = -1;
            int matchIndex = 0;
            // handle the complete source array
            for(int i=0; i<src.Length; i++)
            {
                if(src[i] == find[matchIndex])
                {
                    if (matchIndex==(find.Length-1))
                    {
                        index = i - matchIndex;
                        break;
                    }
                    matchIndex++;
                }
                else
                {
                    matchIndex = 0;
                }
            }
            return index;
        }
        public byte[] ReplaceBytes(byte[] src, byte[] search, byte[] repl)
        {
            byte[] dst = null;
            int index = FindBytes(src, search);
            if (index>=0)
            {
                dst = new byte[src.Length - search.Length + repl.Length];
                // before found array
                Buffer.BlockCopy(src,0,dst,0, index);
                // repl copy
                Buffer.BlockCopy(repl,0,dst,index,repl.Length);
                // rest of src array
                Buffer.BlockCopy(
                    src, 
                    index+search.Length , 
                    dst, 
                    index+repl.Length, 
                    src.Length-(index+search.Length));
            }
            return dst;
        }
