       public partial class FrmMain : Form
       {
          public static void loadNewsFeedItem(Form owner)
          {
             frmNewsFeedView frmFeedView = new frmNewsFeedView(FrmFuncs.selFeedID);
             frmFeedView.ShowDialog(owner);
          }
       }
    }
    
    public class flpNewsFeedHeader : Label
    {
       private int FeedID = 0;
    
       public int theFeedID
       {
          get { return FeedID; }
          set { FeedID = value; }
       }
    
       protected override void OnClick(EventArgs e)
       {
          FrmFuncs.selFeedID = FeedID;
          // Shouldn't need a new thread.  Already on the GUI thread.
          FrmMain.loadNewsFeedItem (System.Windows.Forms.Form.ActiveForm);
       }
    } 
