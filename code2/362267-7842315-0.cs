       DataView m_DataView;
       e.HasMorePages = false;
      for (rowCounter = currentRow; (rowCounter <= (this.DataView.Count - 1)); rowCounter++) 
      {
           float currentRowHeight = PrintDetailRow(leftMargin, currentPosition, this.MinDetailRowHeight, this.MaxDetailRowHeight, width, e, this.DataView(rowCounter), true);
           if ((currentPosition + (currentRowHeight < footerBounds.Y)))
            {
                // it will fit on the page
                   currentPosition = (currentPosition + PrintDetailRow(leftMargin, currentPosition, MinDetailRowHeight, MaxDetailRowHeight, width, e, this.DataView(rowCounter), false));
            }
            else
            {
               e.HasMorePages = true;
               currentRow = rowCounter;
               break;
             }
      
        }
    
    public DataView DataView {
        get {
            return m_DataView;
        }
        set {
            m_DataView = value;
        }
    }
    
    protected object GetField(DataRowView row, string fieldName) {
        object obj = null;
        if (!(m_DataView == null)) {
            obj = row(fieldName);
        }
        return obj;
    }
    
    // relevant snippet out of OnPrintPage
    private int rowCounter;
     
