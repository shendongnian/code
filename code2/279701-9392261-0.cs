        public static void DataTableToCsv(DataTable dt, string filename, CsvOptions options)
        {
            using (var fs = new StreamWriter(filename, false, options.Encoding, EngineBase.DefaultWriteBufferSize))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    object[] fields = dr.ItemArray;
                    for (int i = 0; i < fields.Length; i++)
                    {
                        if (i > 0)
                            fs.Write(options.Delimiter);
                        fs.Write(options.ValueToString(fields[i]));
                    }
                    fs.Write(StringHelper.NewLine);
                }
                fs.Close();
            }
        }
