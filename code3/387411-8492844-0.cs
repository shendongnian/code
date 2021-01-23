        public void Page_Init(object sender, EventArgs e)
        {
            logger.Debug("Page_Init START");
            if (!Page.IsPostBack) { Session["qid"] == 0; }
            int qid = Convert.ToInt32(Session["qid"]);
            if (qid > 0)
            {
                _displaySingleQuestion(_formObject, qid);
            }
            logger.Debug("Page_Init END");
        }
