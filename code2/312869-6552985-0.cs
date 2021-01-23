        void ResizeArray<T>(ref T[,] original, int newCoNum, int newRoNum)
        {
            var newArray = new T[newCoNum,newRoNum];
            int columnCount = original.GetLength(1);
            int columnCount2 = newRoNum;
            int rows = original.GetUpperBound(0);
            for (int ro = 0; ro <= rows; ro++)
                Array.Copy(original, ro * columnCount, newArray, ro * columnCount2, columnCount);
            original = newArray;
        }
