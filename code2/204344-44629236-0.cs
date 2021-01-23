    //Get index of column by header text.
        int GetColumnIndexByName(GridViewRow row, string headerText)
        {
            int columnIndex = 0;
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if(cell.ContainingField is TemplateField){
                    if(((TemplateField)cell.ContainingField).HeaderText.Equals(headerText))
                    {
                        break;
                    } 
                }
              if(cell.ContainingField is BoundField){
                        if (((BoundField)cell.ContainingField).HeaderText.Equals(headerText))
                    {
                        break;
                    }
              }
                columnIndex++; 
            }
            return columnIndex;
        }
