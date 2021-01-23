        public DataTable BuildDataTable<T>(IList<T> data)
        {
            //Get properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //.Where(p => !p.GetGetMethod().IsVirtual && !p.GetGetMethod().IsFinal).ToArray(); //Hides virtual properties
            //Get column headers
            bool isDisplayNameAttributeDefined = false;
            string[] headers = new string[Props.Length];
            int colCount = 0;
            foreach (PropertyInfo prop in Props)
            {
                isDisplayNameAttributeDefined = Attribute.IsDefined(prop, typeof(DisplayNameAttribute));
                if (isDisplayNameAttributeDefined)
                {
                    DisplayNameAttribute dna = (DisplayNameAttribute)Attribute.GetCustomAttribute(prop, typeof(DisplayNameAttribute));
                    if (dna != null)
                        headers[colCount] = dna.DisplayName;
                }
                else
                    headers[colCount] = prop.Name;
                colCount++;
                isDisplayNameAttributeDefined = false;
            }
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Add column headers to datatable
            foreach (var header in headers)
                dataTable.Columns.Add(header);
            dataTable.Rows.Add(headers);
            //Add datalist to datatable
            foreach (T item in data)
            {
                object[] values = new object[Props.Length];
                for (int col = 0; col < Props.Length; col++)
                    values[col] = Props[col].GetValue(item, null);
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
