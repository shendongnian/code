      public partial class _Default : Page
        {
            int NumOfPairs;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack)
                {
                    int.TryParse(Label1.Text, out NumOfPairs);                                
                }
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                Label1.Text = CookSneaker(NumOfPairs).ToString();
            }
    
            public int CookSneaker(int num)
            {
                num += 1;
                return num;
            }
    
        }
