    /// <summary>
        /// Makes the equivalent of a local Excel range that can be populated 
        ///  without leaving .net
        /// </summary>
        /// <param name="iRows">number of rows in the table</param>
        /// <param name="iCols">number of columns in the table</param>
        /// <returns>a 1's based, 2 dimensional object array which can put back to Excel in one DCOM call.</returns>
        public static object[,] NewObjectArray(int iRows, int iCols)
        {
            int[] aiLowerBounds = new int[] { 1, 1 };
            int[] aiLengths = new int[] { iRows, iCols};
            return (object[,])Array.CreateInstance(typeof(object), aiLengths, aiLowerBounds);
        }
