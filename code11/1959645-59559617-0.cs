     dtExcelData.Rows.RemoveAt(0);
     DataTable clone = dtExcelData.Clone();
            string t;
            var qry = from DataRow row in dtExcelData.Rows
                      let arr = row.ItemArray
                      select Array.ConvertAll(arr, s =>
                          (t = s as string) != null
                          && t.StartsWith("\"")
                          && t.EndsWith("\"") ? t.Trim('\"') : s);
            foreach (object[] arr in qry)
            {
                clone.Rows.Add(arr);
            }
