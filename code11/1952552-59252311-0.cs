    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication9
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("produit", typeof(string));
                dt1.Columns.Add("test1", typeof(int));
                dt1.Columns.Add("test3", typeof(int));
                dt1.Columns.Add("logistique", typeof(string));
                dt1.Columns.Add("amount", typeof(string));
                dt1.Rows.Add(new object[] { "P1", 1, 3, "t3;t1;t2", "t4;t5;t6" });
                dt1.Rows.Add(new object[] { "P2", 1, 4, "t9;t10", "t2;t1;t3" });
                DataTable dt2 = dt1.Clone();
                foreach (DataRow row in dt1.AsEnumerable())
                {
                    string produit = row.Field<string>("produit");
                    int test1 = row.Field<int>("test1");
                    int test3 = row.Field<int>("test3");
                    string[] splitLogistique = row.Field<string>("logistique").Split(new char[] { ';' }).ToArray();
                    string[] splitAmount = row.Field<string>("amount").Split(new char[] { ';' }).ToArray();
                    int maxLength = Math.Max(splitLogistique.Length, splitAmount.Length);
                    for(int i = 0; i < maxLength; i++)
                    {
                        if ((i < splitLogistique.Length) && (i < splitAmount.Length))
                        {
                            dt2.Rows.Add(new object[] { produit, test1, test3, splitLogistique[i], splitAmount[i] });
                        }
                        if (i >= splitLogistique.Length)
                        {
                            DataRow newRow = dt2.Rows.Add();
                            newRow.ItemArray = new object[] { produit, test1, test3 };
                            newRow["amount"] = splitAmount[i];
                        }
                        if (i >= splitAmount.Length)
                        {
                            dt2.Rows.Add(new object[] { produit, test1, test3, splitLogistique[i] });
                        }
                    }
                }
            }
        }
    }
