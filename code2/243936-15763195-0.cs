        private void HandleResizeArray()
        {
            int[] aa = new int[2];
            aa[0] = 0;
            aa[1] = 1;
            aa = MyResizeArray(aa);
            aa = MyResizeArray(aa);
        }
        private int[] MyResizeArray(int[] aa)
        {
            Array.Resize(ref aa, aa.GetUpperBound(0) + 2);
            aa[aa.GetUpperBound(0)] = aa.GetUpperBound(0);
            return aa;
        }
