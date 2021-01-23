    private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e) {
                if(e.HitInfo.HitTest ==  GridHitTest.RowCell)    {
                    e.Allow == false;
                    // your code to show menu
                }
            }
