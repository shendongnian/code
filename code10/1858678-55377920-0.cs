    using System;
    using System.Collections.Generic;
    
    namespace RowWiseConcat
    {
        public static class Extension
        {
            // ====================
            // Vladimir's solution
            // ====================
            public static T[][] ConcatArrays<T>(this T[][] array, T[][] concatWith)
            {
    
                var max = Math.Max(array.Length, concatWith.Length);
                var result = new T[max][];
                for (var index = 0; index < max; index++)
                {
                    var list = new List<T>();
                    if (index < array.Length)
                    {
                        list.AddRange(array[index]);
                    }
    
                    if (index < concatWith.Length)
                    {
                        list.AddRange(concatWith[index]);
                    }
    
                    result[index] = list.ToArray();
                }
    
                return result;
            }
        }
    
        class Program
        {
            // ========================================
            // My interpretation of David's suggestion
            // using Valdimir's solution as a basis
            // ========================================
            public static double[][] RowWiseConcatListedJaggedArrays(List<double[][]> listOfJaggedArray)
            {
                var resArray = listOfJaggedArray[0];
    
                for (int rInd = 1; rInd < listOfJaggedArray.Count; rInd++)
                {
                    resArray = resArray.ConcatArrays(listOfJaggedArray[rInd]);
                }
    
                return resArray;
            }
    
            static void Main(string[] args)
            {
    
                // ... do something that results in orgArrayList, e.g.
                double[][] one =
                {
                    new[] {5d, 6},
                    new[] {7d, 9}
                };
                double[][] two =
                {
                    new[] {5d, 6},
                    new[] {7d, 9}
                };
                double[][] three =
                {
                    new[] {5d, 6},
                    new[] {7d, 9}
                };
    
                List<double[][]> orgArrayList = new List<double[][]>()
                    { one, two, three};
                    
                // Concat list items
                var resArray = RowWiseConcatListedJaggedArrays(orgArrayList);
    
                // ... continue with resArray
            }
        }
    }
