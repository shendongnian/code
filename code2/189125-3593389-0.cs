    class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable("TestTable");
                dt.Columns.Add(new DataColumn("id",System.Type.GetType("System.Int32")));
                dt.Columns.Add(new DataColumn("email",System.Type.GetType("System.String")));
    
                ArrayList al = new ArrayList();
                al.Add("one@mail.com");
                al.Add("two@mail.com");
                al.Add("nine@mail.com");
                al.Add("ten@mail.com");
                
    
                DataRow r1 = dt.NewRow();
                r1["id"] = 1;
                r1["email"] = "one@mail.com";
                dt.Rows.Add(r1);
                DataRow r2 = dt.NewRow();
                r2["id"] = 1;
                r2["email"] = "two@mail.com";
                dt.Rows.Add(r2);
                DataRow r3 = dt.NewRow();
                r3["id"] = 1;
                r3["email"] = "three@mail.com";
                dt.Rows.Add(r3);
                DataRow r4 = dt.NewRow();
                r4["id"] = 1;
                r4["email"] = "four@mail.com";
                dt.Rows.Add(r4);
                DataRow r5 = dt.NewRow();
                r5["id"] = 1;
                r5["email"] = "five@mail.com";
                dt.Rows.Add(r5);
               
                var query = from row in dt.AsEnumerable()
                            join String a in al on row.Field<String>("email") equals a into ljtable
                            from a in ljtable.DefaultIfEmpty()
                            where a != null
                            select new { Email = row.Field<String>("email"), Checker = a == null ? "null" : a };
    
                foreach (var v in query)
                {
                    Console.WriteLine(String.Format("Email:{0}   Left Join:{1}", v.Email, v.Checker));
                }
    
                Console.ReadLine();
            }
        }
