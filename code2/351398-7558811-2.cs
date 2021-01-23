    using System;
    using System.Data;
    using MathWorks.MATLAB.NET.Utility;  // MWArray.dll
    using MathWorks.MATLAB.NET.Arrays;   // MWArray.dll
    using CellExample;                   // CellExample.dll assembly created
    
    namespace CellExampleTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // get data table
                DataTable table = getData();
    
                // create the MWCellArray
                int numRows = table.Rows.Count;
                int numCols = table.Columns.Count;
                MWCellArray cell = new MWCellArray(numRows, numCols);   // one-based indices
    
                // fill it cell-by-cell
                for (int r = 0; r < numRows; r++)
                {
                    for (int c = 0; c < numCols; c++)
                    {
                        // fill based on type
                        Type t = table.Columns[c].DataType;
                        if (t == typeof(DateTime))
                        {
                            //cell[r+1,c+1] = new MWNumericArray( convertToMATLABDateNum((DateTime)table.Rows[r][c]) );
                            cell[r + 1, c + 1] = convertToMATLABDateNum((DateTime)table.Rows[r][c]);
                        }
                        else if (t == typeof(string))
                        {
                            //cell[r+1,c+1] = new MWCharArray( (string)table.Rows[r][c] );
                            cell[r + 1, c + 1] = (string)table.Rows[r][c];
                        }
                        else
                        {
                            //cell[r+1,c+1] = new MWNumericArray( (double)table.Rows[r][c] );
                            cell[r + 1, c + 1] = (double)table.Rows[r][c];
                        }
                    }
                }
                // call MATLAB function
                CellClass obj = new CellClass();
                obj.my_cell_function(cell);
    
                // Wait for user to exit application
                Console.ReadKey();
            }
    
            // DateTime <-> datenum helper functions
            static double convertToMATLABDateNum(DateTime dt)
            {
                return (double)dt.AddYears(1).AddDays(1).Ticks / (10000000L * 3600L * 24L);
            }
            static DateTime convertFromMATLABDateNum(double datenum)
            {
                DateTime dt = new DateTime((long)(datenum * (10000000L * 3600L * 24L)));
                return dt.AddYears(-1).AddDays(-1);
            }
    
            // return DataTable data
            static DataTable getData()
            {
                DataTable table = new DataTable();
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Price", typeof(double));
                table.Columns.Add("Date", typeof(DateTime));
    
                table.Rows.Add("Amro", 25, DateTime.Now);
                table.Rows.Add("Bob", 10, DateTime.Now.AddDays(1));
                table.Rows.Add("Alice", 50, DateTime.Now.AddDays(2));
    
                return table;
            }
        }
    }
