    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Matrix
    {
        class Program
        {
            public static List<MatrixItem> CreateSample()
            {
                var list = new List<MatrixItem>();
    
                var countries = new string[] { "          ", "England   ", "Germany   ", "Holland   ", "Spain   ", "Germany   ", "Russia   ", "Japan" };
                for (int i = 0; i < countries.Length; i++)
                {
                    int x = 0;
                    int j = 0;
                    foreach (var item in countries)
                    {
                        var col = item;
                        if (i > 0)
                            col = string.Empty;
                        if (x == 0)
                        {
                            col = countries[i];
                        }
                        if ((j == i) && (i > 0))
                            col = "*";
                        var m = new MatrixItem() { ColData = col, X = x, Y = i };
                        x += item.Length;
                        list.Add(m);
                        j++;
                    }
                }
                return list;
            }
            public static void printMatrix(List<MatrixItem> list)
            {
                var j = 0;
                DosPrinter ds = new DosPrinter(200, 8);
                foreach (var item in list)
                {
                    ds.PrintXY(item.X, item.Y, item.ColData);
                }
                ds.Finilize();
            }
            static void Main(string[] args)
            {
                var s = CreateSample();
                printMatrix(s);
                Console.ReadKey();
            }
        }
        public class MatrixItem
        {
            public string ColData { get; set; }
            public int X{ get; set; }
            public int Y{ get; set; }
            
        }
        public class DosPrinter
        {
            #region Fields
            private int width;
            private int height;
            private byte[,] canvas;
            private int baseX = 0;
            private int baseY = 0;
    
    
            #endregion
    
    
    
            #region Functionality
    
    
            public void PrintXY(int x, int y, string value)
            {
                int startx = baseX + x;// -value.Length;
                for (int i = 0; i < value.Length; i++)
                {
                    canvas[startx + i, baseY + y] = Convert.ToByte(value[i]);
                }
            }
            public void Finilize()
            {
                object k = 1;
                object l = 0;
                object lf = false;
                object ss = " ";
    
                try
                {
                    for (int i = 0; i < height; i++)
                    {
    
                        Array crt = Array.CreateInstance(typeof(byte), baseX + this.width);
                        string line = string.Empty;
                        for (int j = 0; j < baseX + width; j++)
                        {
                            crt.SetValue(canvas[j, i], j);
                            line += ((char)canvas[j, i]).ToString();
                        }
                        Console.WriteLine(line);
                        //vbPrinter.PrintBytes(ref crt, ref LineFeed);
                    }
                }
                catch { }
            }
            public void CleareBuffer()
            {
                InitCanvas();
            }
            public void InitCanvas()
            {
                canvas = new byte[baseX + width, baseY + height];
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        canvas[i, j] = 32;
                    }
                }
            }
            public string DrawLine(int len)
            {
                string line = string.Empty;
                for (int i = 0; i < len; i++)
                {
                    line += "-";
                }
                return line;
            }
            #endregion
    
            #region Constructor
            public DosPrinter(int width, int height)
            {
                this.width = baseX + width;
                this.height = baseY + height;
                InitCanvas();
            }
            #endregion
        }  
    }
