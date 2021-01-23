    private Label feedbackLabel = new Label();
    private TextBox inputTextBox = new TextBox();
    private Button submitButton = new Button();
    public void Page_Init(EventArgs e)
    {
        feedbackLabel.ID = "FeedbackLabel";
    }
    
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        feedbackLabel.Text =...;
    }
