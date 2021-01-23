    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace sandbox
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string[]> specialMacros = new List<string[]>();
                specialMacros.Add(new string[] { "#macro#", "text1" }); 
                specialMacros.Add(new string[] { "#secondmacro#", "text2" });
                var op = specialMacros.ToMultiDimensionalArray();
                Console.Read();
            }
        }
        public static class ArrayHelper
        {
            public static string[,] ToMultiDimensionalArray(this List<string[]> dt)
            {
                int col = dt.FirstOrDefault().ToList().Count();
    
                string[,] arr = new string[dt.Count, col];
                int r = 0;
                foreach (string[] dr  in dt)
                {
                    for (int c = 0; c < col; c++)
                    {
                        arr[r, c] = dr[c];
                    }
                    r++;
                }
                return arr;
            }
        }
        
    
    }
