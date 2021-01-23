    public partial class UserVote : System.Web.UI.UserControl
    {
        private int _currentVode;
        private int _myVoting;
        
        // Move data access to OnInit because this otherwise Page_Load on page
        // fires before control Page_Load.
        protected override void OnInit(EventArgs e)
        {
            DataTable dtVoteInfo = ShowVoteDetail(objectType, objectId);
            if (dtVoteInfo != null)
            {
                if (dtVoteInfo.Rows.Count > 0)
                {
                    int.TryParse(dtVoteInfo.Rows[0]["TOTAL_VOTE"].ToString(), 
                                out _currentVote);
                    int.TryParse(dtVoteInfo.Rows[0]["MY_VOTING"].ToString(), 
                                out _myVoting);
                }
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrVotes.Text = _currentVote.ToString();
            hfCurrentVote.Value = _currentVote.ToString();
            hfMyVote.Value = _myVoting.ToString();
    
            // set img src snipped for brevity....
        }
    
        public int CurrentVote
        {
            get { return _currentVote; }
        }
    
        public int MyVoting
        {
            get { return _myVoting; }
        }
    }
