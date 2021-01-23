            var output= from obj in xmlDoc.Element("extcode")
                                where
                                    obj.Attribute("Type").Value.ToLower() == "abc"
                                select obj;
            DataTable outputTable = new DataTable();
            outputTable.Columns.Add(new DataColumn("code"));
           foreach (var item in output)
                {
                    DataRow outputRows = outputTable.NewRow();
                    if (outputRows != null)
                    {
                    outputRows["Code"] = item.Element("code").Value;
                    }
                  }
          outputTable.Rows.Add(problemsRows);
          outputTable.AcceptChanges();
