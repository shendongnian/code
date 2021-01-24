    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication9
    {
        class Program
        {
            const int HEADER_COLS = 3;
            static void Main(string[] args)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("produit", typeof(string));
                dt1.Columns.Add("test1", typeof(int));
                dt1.Columns.Add("test3", typeof(int));
                dt1.Columns.Add("logistique", typeof(string));
                dt1.Columns.Add("amount", typeof(string));
                dt1.Columns.Add("testAjout", typeof(string));
                dt1.Columns.Add("testAjout1", typeof(string));
                dt1.Rows.Add(new object[] { "P1", 1, 3, "t3;t1;t2", "t4;t5;t6;tr", "T34;T25", "Rahima;T33;T55;T66" });
                dt1.Rows.Add(new object[] { "P2", 1, 4, "t9;t10;t55", "t2;t1;t3", "t34;t45", "Nadji" });
                DataTable dt2 = dt1.Clone();
                int cols = dt1.Columns.Count;
                foreach (DataRow row in dt1.AsEnumerable())
                {
                    string produit = row.Field<string>("produit");
                    int test1 = row.Field<int>("test1");
                    int test3 = row.Field<int>("test3");
                    //[column][number items spit by semicolon]
                    string[][] splitData = row.ItemArray.Skip(HEADER_COLS).Select(x => ((string)x).Split(new char[] { ';'}).ToArray()).ToArray();
                    int maxLength = splitData.Select(x => x.Length).Max();
                    //add rows to data table using column with most semicolons
                    for (int i = 0; i < maxLength; i++)
                    {
                        DataRow newRow = dt2.Rows.Add();
                        newRow.ItemArray = new object[] { produit, test1, test3 };
                        for(int col = HEADER_COLS; col < cols; col++)
                        {
                            if ( i < splitData[col - HEADER_COLS].Length)
                            {
                                newRow[col] = splitData[col - HEADER_COLS][i];
                            }
                        }
                    }
                }
            }
        }
    }
