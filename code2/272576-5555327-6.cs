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
