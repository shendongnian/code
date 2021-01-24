                    string[,] str = new string[YourDataTable.Rows.Count, 2]; 
                    int i = 0;
                    foreach (DataRow row in YourDataTable.Rows)
                    {
                        if (i < YourDataTable.Rows.Count)
                        {
                            str[i, 1] = row["name"].ToString();
                            str[i, 2] = row["age"].ToString();
                            i++;
                        }
                    }
