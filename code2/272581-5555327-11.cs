        ListDictionary sortOrderLD = new ListDictionary(); //if less than 10 columns
        private SortOrder SetOrderDirection(string column)
        {
            if (sortOrderLD.Contains(column))
            {
                sortOrderLD[column] = (SortOrder)sortOrderLD[column] == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                sortOrderLD.Add(column, SortOrder.Ascending);
            }
            return (SortOrder)sortOrderLD[column];
        }
