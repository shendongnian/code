    static public int GetColumnIndex(GridView gv, string columnName)
    {
        int returnMe = -1;
        for (int i = 0; i < gv.Columns.Count; i++)
        {
            if (gv.Columns[i].HeaderText == columnName)
            {
                returnMe = i;
                break;
            }
        }
        return returnMe;
    }
