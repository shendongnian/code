        private void productGridview_Cellclick(object sender, DataGridViewCellEventArgs e)
        {
          // Bad index
          if (e.ColumnIndex != productgridview.Columns["productimage"].Index) return;
          
          // No selection
          if (productgridview.SelectedCells.Count == 0) return;
          // Make sure we have an image in this cell.
          object selectedValue = productgridview.SelectedCells[0].Value;
          if (selectedValue is Image) 
          {
              // Forms are IDisposable, so use them embedded in a using statement.
              using (ProductDescriptionForm pf = new ProductDescriptionForm())
              {
                  pf.Picture = (Image)selectedValue;
                  pf.ShowDialog(this);
              }
          }
       }
