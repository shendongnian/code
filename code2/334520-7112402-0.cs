    using System;
    using System.Data;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                var deletedClients = GetDataTable();
    
                // Using linq to create the new DataTable.
                var example1 = deletedClients.AsEnumerable()
                                             .Where(x => x.Field<int>("ClinicId") == 1)
                                             .CopyToDataTable();
    
                // Using the DefaultView RowFilter to create a new DataTable.
                deletedClients.DefaultView.RowFilter = "ClinicId = 1";
                var rowFilterExample = deletedClients.DefaultView.ToTable();
            }
    
            static DataTable GetDataTable()
            {
                var dataTable = new DataTable();
                // Assumes ClinicId is an int...
                dataTable.Columns.Add("ClinicId", typeof(int));
                dataTable.Columns.Add("Reason");
                dataTable.Columns.Add("Number", typeof(int));
                dataTable.Columns.Add("Percentage", typeof(float));
    
                for (int counter = 0; counter < 10; counter++)
                {
                    dataTable.Rows.Add(counter, "Reason" + counter, counter, counter);
                }
    
                return dataTable;
            }
        }
    }
