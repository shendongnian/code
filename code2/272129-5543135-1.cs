       public void LoadQuestionPanelControl()
        {
            Session.Add("ID",id);
            Control c = Page.LoadControl("QuestionPanelControl.ascx");
            var q1= c as QuestionPanelControl;
            if(q1 != null)
            {
                q1.ID = "QuestionPanelControl1";
           
                PlaceHolder1.Controls.Clear();
                PlaceHolder1.Controls.Add(q1);
            }
    
        }
