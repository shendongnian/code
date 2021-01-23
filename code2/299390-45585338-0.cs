     if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
                try
                {
                    
                    XElement xe = XElement.Load(filepath);
                  // 
                    
                    string sql = "insert OR IGNORE into price_list (name,his_code,specs,unit,spell,price) values(@name,@his_code,@specs,@unit,@spell,@price);";
                    int count = 0;
                    foreach (XElement el in xe.Descendants("row"))
                    {
                        SQLiteParameter[] ps =
                        {
                            new SQLiteParameter("@his_code",el.Element("aka079").Value),
                            new SQLiteParameter("@name",el.Element("aka061").Value),
                            new SQLiteParameter("@specs",el.Element("aka073").Value),
                            new SQLiteParameter("@unit",el.Element("aka067").Value),
                            new SQLiteParameter("@spell",SpellCode.GetSpellCode(el.Element("aka061").Value)),
                            new SQLiteParameter("@price",el.Element("aka071").Value),
                        };
                        if (SqliteHelper.ExecuteNonQuery(sql, ps) > 0)
                        {
                            count++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
