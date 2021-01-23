    public class MyListView : ListView
    {
        public MyListView()
        {
            OwnerDraw = true;
            DrawItem += new DrawListViewItemEventHandler(MyListView_DrawItem);
        }
    
        private void MyListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.Graphics.DrawString(e.Item.Text, e.Item.Font, 
                                        new SolidBrush(e.Item.ForeColor), e.Bounds);
        }
    }
