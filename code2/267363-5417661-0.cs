    public void AddNewRow(int tableId, int rowCount)
        {
            object[] oParams = new object[1];
            oParams[0] = tableId;
            object table_ = tables.GetType().InvokeMember("Item",
            BindingFlags.InvokeMethod,
            null,
            tables,
            oParams);
            object rows = table_.GetType().InvokeMember("Rows",
            System.Reflection.BindingFlags.GetProperty,
            null,
            table_,
            null);
            oParams = new object[1];
            if (rowCount == 1)
            {
                object row = rows.GetType().InvokeMember("Add",
                BindingFlags.InvokeMethod,
                null,
                rows,
                null);
            }
            else
            {
                for (int i = 0; i < rowCount; i++)
                {
                    object row = rows.GetType().InvokeMember("Add",
                BindingFlags.InvokeMethod,
                null,
                rows,
                null);
                }
            }
        }
