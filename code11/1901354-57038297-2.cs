    using System.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    
    public partial class Program
            {
           static DataTable dt;
            Program()
            {
                Initializer();
            }
            class DataItem
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
            public void Initializer()
            {
                dt = new DataTable();
                //Columns Add
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                //Row of Data Add
                dt.Rows.Add(1, "Elango");
                dt.Rows.Add(2, "Ampa");
                dt.Rows.Add(3, "Madhu");
            }        
        }
    
    public partial class Program
        {
            public static void Main()
            {
                Program pg = new Program();
                DataTable dts = dt;
    			
    			List<DataItem> studentList = new List<DataItem>();  
    			
        studentList = (from DataRow dr in dt.Rows  
                select new DataItem()  
                {  
                    Id = Convert.ToInt32(dr["Id"]),  
                    Name = dr["Name"].ToString()
                }).ToList();  
            }
        }
