        private void Transform(DataTable table)
        {
            table.Columns.Add("EnumValue", typeof(SomeEnum));
            foreach (DataRow row in table.Rows)
            {
                int value = (int)row[1]; //int representation of enum
                row[2] = (SomeEnum)value;
            }
        }
