      List<int> data = new List<int>();
                    int nCurrentYear = DateTime.Now.Year - 10;
                    foreach (int yearCount in Enumerable.Range(1, 20))
                    {
                        data.Add(nCurrentYear + yearCount);
                    }
                    Combo.Properties.DataSource = data;
                    Combo.EditValue = DateTime.Now.Year;
