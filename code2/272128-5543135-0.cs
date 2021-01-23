    public void LoadQuestionPanelControl()
        {
            Session.Add("ID",id);
            q1= new QuestionPanelControl();
            q1.ID = "QuestionPanelControl1";
            PlaceHolder1.Controls.Clear();
            PlaceHolder1.Controls.Add(q1);
    
        }
