    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable customerTable = new DataTable();
                customerTable.Columns.Add("ID", typeof(int));
                customerTable.Columns.Add("Name", typeof(string));
                customerTable.Columns.Add("Surname", typeof(string));
                customerTable.Rows.Add(new object[] {1, "Joe", "Doe"});
                customerTable.Rows.Add(new object[] {2, "Jim", "White"});
                DataTable orderTable = new DataTable();
                orderTable.Columns.Add("Customer_ID", typeof(int));
                orderTable.Columns.Add("ID", typeof(int));
                orderTable.Columns.Add("o_date", typeof(DateTime));
                orderTable.Columns.Add("code", typeof(string));
                orderTable.Rows.Add(new object[] {1, 1, DateTime.Parse("01/01/2019"), "o001"});
                orderTable.Rows.Add(new object[] {1, 2, DateTime.Parse("01/01/2019"), "o002"});
                orderTable.Rows.Add(new object[] {2, 3, DateTime.Parse("01/01/2019"), "o003"});
                DataTable caseTable = new DataTable();
                caseTable.Columns.Add("Customer_ID", typeof(int));
                caseTable.Columns.Add("ID", typeof(int));
                caseTable.Columns.Add("o_date", typeof(DateTime));
                caseTable.Columns.Add("code", typeof(string));
                caseTable.Rows.Add(new object[] {2, 1, DateTime.Parse("01/01/2019"), "issue 001"});
                var results = (from cust in customerTable.AsEnumerable()
                               join order in orderTable.AsEnumerable() on cust.Field<int>("ID") equals order.Field<int>("ID")
                               join caseT in caseTable.AsEnumerable() on cust.Field<int>("ID") equals caseT.Field<int>("ID")
                               select new { cust = cust, order = order, caseT = caseT })
                               .ToList();
            }
        }
    }
     
