        protected void Submit(object sender, EventArgs e)
        {
            List<string> answers = new List<string>();
            answers.Add(Session["Q1"].ToString());
            answers.Add(Session["Q2"].ToString());
            answers.Add(Session["Q3"].ToString());
            // Do stuff with answers
        }
