    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var answers = int.Parse(hfDynamicAnswers.Value);
        for (int i = 1; i <= answers; i++)
        {
            var answer = Request.Params["ans_clone_" + i.ToString()];
        }
    }
