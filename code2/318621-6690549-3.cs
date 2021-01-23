        public virtual void LoadDataRow(DataRow drow, params string[] parameters)
        {
            this.LoadDataRow(drow);
            foreach (string property in parameters)
            {
                try
                {
                    if (drow[property] != null)
                    {
                        PropertyInfo pi = this.GetType().GetProperty(property);
                        if (pi != null && drow.Table.Columns.Contains(property))
                        {
                            pi.SetValue(this, drow[property], null);
                        }
                    }
                }
                catch { throw; }
            }
        }
