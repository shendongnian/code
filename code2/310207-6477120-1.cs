    class Default : Page
    {
        q.NavigateUrl = "AnswerQuestion.aspx?x=5";
    }
    
    class AnswerQuestion : Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            string x = this.Request.QueryString["x"];
            int i;
            if (!Int32.TryParse(x, out i))
                throw new Exception("Can't parse x as int");
            // then use i
        }
    }
