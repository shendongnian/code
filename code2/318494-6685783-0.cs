            DataTable CSVFile = new DataTable();
            CSVFile.Columns.Add("Occurrence_Date", typeof(DateTime));
            CSVFile.Columns.Add("Preanalytical_Before_Testing", typeof(string));
            CSVFile.Columns.Add("Cup_Type", typeof(string));
            CSVFile.Columns.Add("Analytical_Testing_Phase", typeof(string));
            CSVFile.Columns.Add("Area", typeof(string));
            CSVFile.Columns.Add("Postanalytical_After_Testing", typeof(string));
            CSVFile.Columns.Add("Other", typeof(string));
            CSVFile.Columns.Add("Practice_Code", typeof(string));
            CSVFile.Columns.Add("Comments", typeof(string));
            for (int i = 0; i < 10; i++)
            {
                DataRow row = CSVFile.NewRow();
                row[0] = DateTime.Now.AddDays(i);
                row[1] = "Field 2";
                row[2] = "Field 3";
                row[3] = "Field 4";
                row[4] = "Field 5";
                row[5] = "Field 6";
                row[6] = "Field 7";
                row[7] = "Field 8";
                row[8] = "Field 9";
                CSVFile.Rows.Add(row);
            }
