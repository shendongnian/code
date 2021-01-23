    public static void ChangeHeaders(DataGridView dataGrid, Dictionary<String, String> data)
            {
                if (data == null)
                {
                    return;
                }
                Dictionary<string, string>.Enumerator enumerator = data.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    try
                    {
                        dataGrid.Columns[enumerator.Current.Key].HeaderText = enumerator.Current.Value;
                    }
                    catch (NullReferenceException e)
                    {
                        throw new ArgumentException("The column " + enumerator.Current.Key + " does not exist");
                    }
                }
            }
