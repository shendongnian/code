     /// <summary>
        /// byte[]替换 (如果 搜索目标或替换目标为null，直接返回源数组)
        /// </summary>
        /// <param name="src">替换源数组</param>
        /// <param name="search">需要被替换目标数组</param>
        /// <param name="repl">替换进入的数组</param>
        /// <returns>完成替换的byte[]</returns>
        public static byte[] ReplaceBytes(byte[] src, byte[] search, byte[] repl)
        {
            if (repl == null) return src;
            int index = FindBytes(src, search);
            if (index < 0) return src;
            byte[] dst = new byte[src.Length - search.Length + repl.Length];
            Buffer.BlockCopy(src, 0, dst, 0, index);
            Buffer.BlockCopy(repl, 0, dst, index, repl.Length);
            Buffer.BlockCopy(src, index + search.Length, dst, index + repl.Length,src.Length - (index + search.Length));
            return dst;
        }
        /// <summary>
        /// 在目标数组中查找指定目标第一次出现的索引（没有指定目标返回-1）
        /// </summary>
        /// <param name="src">查找源</param>
        /// <param name="find">需要查找的目标</param>
        /// <returns>第一次出现的索引（没有指定目标返回-1）</returns>
        public static int FindBytes(byte[] src, byte[] find)
        {
            if(src==null|| find==null|| src.Length==0|| find.Length == 0 || find.Length> src.Length) return -1;
            for (int i = 0; i < src.Length - find.Length +1 ; i++)
            {
                if (src[i] == find[0])
                {
                   for(int m=1;m< find.Length;m++)
                   {
                        if (src[i + m] != find[m]) break;
                        if (m == find.Length - 1) return i;
                   }
                }
            }
            return -1;
        }
