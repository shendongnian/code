    if (dataTable != null)
   {
        DataView dataView = new DataView(dataTable);
        if (GridViewSortExpression != string.Empty)
       {
            if (isPageIndexChanging)
           {
                dataView.Sort = string.Format("{0} {1}",  GridViewSortExpression,GridViewSortDirection);
           }
           else
           {
                dataView.Sort = string.Format("{0} {1}",  GridViewSortExpression,ToggleSortDirection());
           }
       }
    return dataView;
