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
              DataColumn col; 
              DataTable table1 = new DataTable(); 
              table1.PrimaryKey = new DataColumn[] { 
              col = table1.Columns.Add("slot_id") 
               }; 
              col.DataType = typeof(int); 
              col.Unique = true; 
              col = table1.Columns.Add("appointment_time"); 
              col = table1.Columns.Add("patient_name"); 
              col = table1.Columns.Add("patient_doctor"); 
    
              table1.Rows.Add(1, "0900", "George Michael"); 
    
              DataTable table2 = new DataTable(); 
              table2.PrimaryKey = new DataColumn[] { 
              col = table2.Columns.Add("slot_id") 
               }; 
              col.DataType = typeof(int); 
              col.Unique = true; 
             col = table2.Columns.Add("appointment_time"); 
    
              table2.Rows.Add(1, "0900"); 
              table2.Rows.Add(2, "1000"); 
              table2.Rows.Add(3, "1100"); 
              table2.Rows.Add(4, "1200"); 
    
             DataTable merged = new DataTable(); 
            merged.Merge(table1); 
            merged.Merge(table2); 
    
            foreach (DataColumn dc in merged.Columns) 
            Console.Write(dc.ColumnName + "\t"); 
            Console.WriteLine(); 
    
           foreach (DataRow dr in merged.Rows) 
           { 
                foreach (DataColumn dc in merged.Columns) 
                Console.Write(dr[dc.ColumnName] + "\t"); 
                Console.WriteLine(); 
           } 
           Console.WriteLine(); 
     
           Console.Write("Press any key to continue . . . "); 
           Console.ReadKey(true); 
           Console.WriteLine(); 
        } 
      } 
    } 
