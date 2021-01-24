       private DataTable ConvertToDataTable(string FilePath)
        {
            var lines = File.ReadAllLines(FilePath);
            DataTable dt2 = new DataTable();
            dt2.Clear();
            dt2.Columns.Add("Col0");
            dt2.Columns.Add("Col1");
            dt2.Columns.Add("Col2");
            dt2.Columns.Add("Col3");
            dt2.Columns.Add("Col4");
            dt2.Columns.Add("Col5");
            dt2.Columns.Add("Col6");
            for (int i = 0; i < lines.Length; i++)
            {
                var str = lines[i];
                if (i > 0)
                {
                    var strarray = str.Split('|');
                    DataRow _dr2 = dt2.NewRow();
                    for (int count = 0; count <= strarray.Length - 1; count++)
                    {
                        if (count == 0)
                            _dr2["Col0"] = strarray[count];
                        else if (count == 1)
                            _dr2["Col1"] = strarray[count];
                        else if (count == 2)
                            _dr2["Col2"] = strarray[count];
                        else if (count == 3)
                            _dr2["Col3"] = strarray[count];
                        else if (count == 4)
                            _dr2["Col4"] = strarray[count];
                        else if (count == 5)
                            _dr2["Col5"] = strarray[count];
                        else if (count == 6)
                            _dr2["Col6"] = strarray[count];
                    }
                    dt2.Rows.Add(_dr2);
                }
            }
            return dt2;
        }
