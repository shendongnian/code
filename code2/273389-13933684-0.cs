        private void LoadStuffNames()
        {
            try
            {
                    string Query = "select stuff_name from dbo.stuff";
                    string[] names = GetColumnData_FromDB(Query);
                    comboName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    comboName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection x = new AutoCompleteStringCollection();
                    if (names != null && names.Length > 0)
                        foreach (string s in names)
                            x.Add(s);
                    comboName.AutoCompleteCustomSource = x;
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
