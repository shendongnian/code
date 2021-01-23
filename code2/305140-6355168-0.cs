     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PanelFirstQuestionBlock.Visible = true;
        }
    }
    protected void FirstQuestionGotAnswered(object sender, EventArgs e)
    {
        PanelFirstQuestionBlock.Visible = false;
        PanelSecondQuestionBlock.Visible = true;
    }  
