       private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
       {     
            GridViewInfo viewInfo = gridView1.GetViewInfo() as GridViewInfo;
            if (viewInfo != null)
            {
                gridView1.TopRowIndex = (int)(
                          (gridView1.RowCount - viewInfo.RowsInfo.Count)
                          *
                          (1 + (1.0 * vScrollBar1.LargeChange / vScrollBar1.Maximum))
                          *
                          vScrollBar1.Value / vScrollBar1.Maximum
                         );
            }
        }
