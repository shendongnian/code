            StringBuilder str = new StringBuilder();
            foreach (DataTable dt in tempDataDS.Tables)
            {
                foreach (DataRow item in dt.Rows)
                {
                    foreach (object field in item.ItemArray)
                    {
                        str.Append(field.ToString() + ",");
                    }
                    str.Replace(",", Environment.NewLine, str.Length - 1, 1);
                }
            }
            try
            {
                File.AppendAllText("C:\\temp\\tempData.csv", str.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while writing content to csv file. \nException details: {0}", ex.ToString());
            }
