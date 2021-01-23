    public static void ForEach(this DataGridViewColumnCollection cols, Action<DataGridViewColumn> action)
        {
            foreach (DataGridViewColumn col in cols)
            {
                action(col);
            }
        }
