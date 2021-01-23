    public static class MyTools
    {
        public static int IndexByName(this DataGridView dgv, string name)
        {
            foreach(DataGridViewColumn col in dgv.Columns)
            {
                if(col.HeaderText.ToUpper().Trim() == name.ToUpper().Trim())
                {
                    return col.Index;
                }
            }
            return -1;
        }
    }
