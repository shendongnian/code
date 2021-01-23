    using System;
    
    namespace InteropExcel {
        class Program {
            static void Main(string[] args) {
                Random rand = new Random();
                double[] yDatapoints = new double[3];
                for (int i = 0; i < 3; i++) {
                    yDatapoints[i]=rand.Next(20, 60);
                }
                double[,] xAll = new double[12, 3];
                for (int i = 0; i < 12; i++) {
                    for (int j = 0; j < 3; j++) {
                        
                        xAll[i, j] = rand.Next(2, 100);
                    }
                }
                Microsoft.Office.Interop.Excel.Application xl = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.WorksheetFunction wsf = xl.WorksheetFunction;
                object[,] result = (object[,])wsf.LinEst(yDatapoints, xAll, Type.Missing, true);
    
    
    
            }
        }
    }
