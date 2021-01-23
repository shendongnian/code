        static int[] AllIntegers()
        {
            int iSize = int.MaxValue;
            int[] all;
            int divider = 2;
            while (true)
            {
                try
                {
                    all = new int[iSize];
                    break;
                }
                catch (OutOfMemoryException)
                {
                    iSize = iSize/divider ;
                }
            }
            //Probably will fail again. how to efficently loop the catch again
            for (int i = 0; i < all.Length; i++)
            {
                all[i] = i;
            }
            return all;
        }
