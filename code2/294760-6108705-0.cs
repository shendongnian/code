    public void SetGridColumnProperty(ref DataGridView grid,string columnName, string propretyName, string propertyValue  )
            {
                PropertyInfo pInfo =  grid.GetType().GetProperty(propretyName);
                if (pInfo != null)
                {
                   TypeConverter tc = TypeDescriptor.GetConverter(pInfo.PropertyType);
                   if (tc.CanConvertFrom(Type.GetType(propertyValue.GetType().ToString())))
                   {
                       valToSet = tc.ConvertFromString(propertyValue);
                       pInfo.SetValue(grid, valToSet, null);
                   }
                }
            }
