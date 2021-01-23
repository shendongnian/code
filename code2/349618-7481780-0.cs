     private void yourGridViewName_DoubleClick(object sender, EventArgs e)
            {
                DevExpress.XtraGrid.Views.Grid.GridView sndr =
                        sender as DevExpress.XtraGrid.Views.Grid.GridView;
    
                DevExpress.Utils.DXMouseEventArgs dxMouseEventArgs =
                    e as DevExpress.Utils.DXMouseEventArgs;
    
    
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo =
                   sndr.CalcHitInfo(dxMouseEventArgs.Location);
    
                if (hitInfo.InColumn)
                {
                   string x = hitInfo.Column.Name;
                
                  //Rest of your logic goes here after getting the column name, 
                 //You might now loop over your grid's data and do your logic
               }
        }
