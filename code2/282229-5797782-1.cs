            DataTable employeeData = GetEmployeeData();
            // Create a view based on the data so that we can sort it by Dept
            DataView view = employeeData.DefaultView;
            view.Sort = "Dept";
            if (!employeeData.Columns.Contains("Dept"))
            {
                Console.WriteLine("Employee Data file does not contain department column.");
                return;
            }
            // Print the column headers
            foreach (DataColumn column in employeeData.Columns)
            {
                Console.Write("{0,-9}", column.ColumnName);
            }
            Console.WriteLine();
            // Print each row in order
            foreach (DataRow row in view)
            {
                foreach (DataColumn column in employeeData.Columns)
                {
                    Console.Write("{0,-9}", row[column]);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
