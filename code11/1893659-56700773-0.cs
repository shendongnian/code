    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication116
    {
        class Program
        {
            static DataTable dt;
            static void Main(string[] args)
            {
                dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("TopDepartmentId", typeof(int));
                dt.Columns.Add("DepartmentName", typeof(string));
                dt.Rows.Add(new object[] { 1, null, "Software Development" });
                dt.Rows.Add(new object[] { 2, 1, "Mobile Development" });
                dt.Rows.Add(new object[] { 3, 1, "Web Development" });
                dt.Rows.Add(new object[] { 4, 2, "IOS Development" });
                dt.Rows.Add(new object[] { 5, 2, "Android Development" });
                dt.Rows.Add(new object[] { 6, 4, "Swift Development" });
                dt.Rows.Add(new object[] { 7, 4, "Objective-C Development" });
                GetTree(null, 0);
                Console.ReadLine();
            }
            static void GetTree(int? parent, int level)
            {
                DataRow[] children = dt.AsEnumerable().Where(x => x.Field<int?>("TopDepartmentId") == parent).ToArray();
                foreach (DataRow child in children)
                {
                    int childId = child.Field<int>("Id");
                    Console.WriteLine("{0}ID : '{1}', TopDepartmentId : '{2}', DepartmentName : '{3}'", 
                        new string(' ', 5 * level), 
                        childId.ToString(), 
                        (child.Field<object>("TopDepartmentId") == null) ? "BOSS" : child.Field<int?>("TopDepartmentId").ToString(),
                        child.Field<string>("DepartmentName"));
                    GetTree(childId, level + 1);
                }
            }
     
        }
     
    }
