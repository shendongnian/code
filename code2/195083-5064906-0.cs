        foreach (DataControlField field in _GridView.Columns)
        {
            if (field.SortExpression == name)
            {
                return _GridView.Columns.IndexOf(field);
            }
        }
        return -1;
    }
