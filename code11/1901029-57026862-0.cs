            string[] cols;
            string[] rows;
            int cnt;
            StreamReader sr = new StreamReader(sourceFile);  //SOURCEFILE
           
            string line = sr.ReadLine();
            cols = Regex.Split(line, ",");
            DataTable table = new DataTable();
            for (int i = 0; i < cols.Length; i++)
            {
                table.Columns.Add(cols[i], typeof(string));
            }
            while ((line = sr.ReadLine()) != null)
            {
                table.Rows.Clear();
                int i;
                string row = string.Empty;
                rows = Regex.Split(line, ",");
                DataRow dr = table.NewRow();
                for (i = 0; i < rows.Length; i++)
                {
                    dr[i] = rows[i];
                    cnt = i;
                }
                table.Rows.Add(dr);
                string desti = destination + Guid.NewGuid(); //Destination file
                StreamWriter sw = new StreamWriter(desti);
                string json = JsonConvert.SerializeObject(table, Formatting.Indented);
                sw.Write(json);
                sw.Close();
            }
            
            sr.Close();
