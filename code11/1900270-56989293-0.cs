            IEnumerable<DataRow> dataRows;
            using (var dataSet = new DataSet())
            {
                using (var command = new SqlCommand($"select Name, Value from Table where PId={id} and type<>{(int) Enum.PElement}", con))
                {
                    using (var sda2 = new SqlDataAdapter(command))
                    {
                        sda2.Fill(dataSet);
                    }
                }
                dataRows = dataSet.Tables[0].Rows.OfType<DataRow>();
            }
            return dataRows.ToDictionary(row => row["Name"].ToString(), row => row["Value"].ToString());
