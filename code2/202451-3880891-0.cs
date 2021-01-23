    public partial class UserVote : System.Web.UI.UserControl
    {
        public int ObjectType { get; set; }
        public int ObjectId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtVoteInfo = ShowVoteDetail(ObjectType, ObjectId);
            ...
        }
    }
