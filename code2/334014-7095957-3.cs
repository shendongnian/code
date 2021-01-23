        private void productGridview_Cellclick(object sender, DataGridViewCellEventArgs e)
        {
          if (e.ColumnIndex == productgridview.Columns["productimage"].Index)
          {
              ProductDescriptionForm pf = new ProductDescriptionForm();
              pf.Picture = (Image)productgridview.SelectedCells[0].Value;
              pf.ShowDialog(this);
          }
       }
