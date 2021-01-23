        public virtual void LoadDataRow(DataRow drow, params string[] parameters)
        {
            foreach (string property in parameters)
            {
                try
                {
                    if (drow[property] != null)
                    {
                        PropertyInfo pi = this.GetType().GetProperty(property);
                        pi.SetValue(this, drow[property], null);
                    }
                }
                catch { /* Ignore! */ }
            }
        }
