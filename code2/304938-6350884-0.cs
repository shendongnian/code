    public partial class FrmMain : Form
    {
        private static FrmMain staticInstance;
        public FrmMain()
        {
           staticInstance = this;
        }
        public static void loadNewsFeedItem()
        {
            frmNewsFeedView frmFeedView = new frmNewsFeedView(FrmFuncs.selFeedID);
            frmFeedView.ShowDialog(staticInstance ); 
        }
