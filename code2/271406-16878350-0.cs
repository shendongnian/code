     private static GridHitInfo DoRowDoubleClick(GridView view, Point pt) {
    
                GridHitInfo info = view.CalcHitInfo(pt);
    
                if (info.InRow || info.InRowCell){
    
                    string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
    
                    MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));
                    return info;
                }
                return null;
            }
