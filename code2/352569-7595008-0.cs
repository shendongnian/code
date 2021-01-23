    public class AutoHeightHelper
    {
        GridView view;
        public AutoHeightHelper(GridView view)
        {
            this.view = view;
            EnableColumnPanelAutoHeight();
        }
    
        public void EnableColumnPanelAutoHeight()
        {
            SetColumnPanelHeight();
            SubscribeToEvents();
        }
    
        private void SubscribeToEvents()
        {
            view.ColumnWidthChanged += OnColumnWidthChanged;
            view.GridControl.Resize += OnGridControlResize;
            view.EndSorting += OnGridColumnEndSorting;
        }
    
        void OnGridColumnEndSorting(object sender, EventArgs e)
        {
            view.GridControl.BeginInvoke(new MethodInvoker(SetColumnPanelHeight));
        }
    
        void OnGridControlResize(object sender, EventArgs e)
        {
            SetColumnPanelHeight();
        }
    
        void OnColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            SetColumnPanelHeight();
        }
    
        private void SetColumnPanelHeight()
        {
            GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;
            int height = 0;
            for (int i = 0; i < view.VisibleColumns.Count; i++)
                height = Math.Max(GetColumnBestHeight(viewInfo, view.VisibleColumns[i]), height);
            view.ColumnPanelRowHeight = height;
        }
    
        private int GetColumnBestHeight(GridViewInfo viewInfo, GridColumn column)
        {
            GridColumnInfoArgs ex = viewInfo.ColumnsInfo[column];
            GraphicsInfo grInfo = new GraphicsInfo();
            grInfo.AddGraphics(null);
            ex.Cache = grInfo.Cache;
            bool canDrawMore = true;
            Size captionSize = CalcCaptionTextSize(grInfo.Cache, ex as HeaderObjectInfoArgs, column.GetCaption());
            Size res = ex.InnerElements.CalcMinSize(grInfo.Graphics, ref canDrawMore);
            res.Height = Math.Max(res.Height, captionSize.Height);
            res.Width += captionSize.Width;
            res = viewInfo.Painter.ElementsPainter.Column.CalcBoundsByClientRectangle(ex, new Rectangle(Point.Empty, res)).Size;
            grInfo.ReleaseGraphics();
            return res.Height;
        }
    
        Size CalcCaptionTextSize(GraphicsCache cache, HeaderObjectInfoArgs ee, string caption)
        {
            Size captionSize = ee.Appearance.CalcTextSize(cache, caption, ee.CaptionRect.Width).ToSize();
            captionSize.Height++; captionSize.Width++;
            return captionSize;
        }
    
        public void DisableColumnPanelAutoHeight()
        {
            UnsubscribeFromEvents();
        }
    
        private void UnsubscribeFromEvents()
        {
            view.ColumnWidthChanged -= OnColumnWidthChanged;
            view.GridControl.Resize -= OnGridControlResize;
            view.EndSorting -= OnGridColumnEndSorting;
        }
    }
