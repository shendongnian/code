                OleDbConnection conn1 = new OleDbConnection(strConnection);
                conn1.Open();
                DataTable dt = new DataTable();
                dt = conn1.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });
                Object sheetName = dt.Rows[0]["TABLE_NAME"];
                dt.Clear();
                dt.Columns.Clear();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [" + sheetName.ToString() + "]", conn1);
                da.TableMappings.Add("Table", "0");
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ID = dt.Rows[i][0].ToString();
                    string Name = dt.Rows[i][1].ToString();
                    string City = dt.Rows[i][2].ToString();
                    string Marks = dt.Rows[i][3].ToString();
                }
                conn1.Close();
            }
            catch
            {
                throw;
            }
