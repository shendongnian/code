    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.OleDb;
    namespace ConsoleApplication124
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                string connStr = "Provider=Microsoft.ACE.OLEDB.15.0;Data Source=c:\\temp\\test.xlsx;Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"";
                string query = "Select * From [Sheet1$]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connStr);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                string[] days = dt.Rows[0].ItemArray.Skip(1).Select(x => (x == DBNull.Value) ? string.Empty : ((string)x).Trim()).ToArray();
                string[] people = dt.Rows[1].ItemArray.Skip(1).Select(x => (x == DBNull.Value) ? string.Empty : ((string)x).Trim()).ToArray();
                int numberDays = days.Where(x => x != string.Empty).Count();
                int numberPeople = people.Where(x => x != string.Empty).Distinct().Count();
                string[] columnNames = { "Shop_Name", "Day", "Member_Name", "Point" };
                Console.WriteLine(string.Join(",", columnNames));
                for (int row = 2; row < dt.Rows.Count; row++)
                {
                    string[] columns = dt.Rows[row].ItemArray.Select(x => (x == DBNull.Value) ? string.Empty : ((string)x).Trim()).ToArray();
                    string shop = columns[0];
                    for (int col = 1; col < dt.Rows[row].ItemArray.Count(); col++)
                    {
                        object point = dt.Rows[row].Field<string>(col);
                        if (point != null)
                        {
                            string pointStr = ((string)point).Trim();
                            int dayIndex = numberPeople * ((col - 1) / numberPeople);
                            string day = days[dayIndex];
                            string person = people[col - 1];
                            string[] outputData = { shop, day, person, pointStr };
                            Console.WriteLine(string.Join(",", outputData));
                        }
                    }
                }
                Console.ReadLine();
            }
        }
     
    }
