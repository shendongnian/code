    //Form1, question 1
    List<string> survey = new List<string>();
    survey.Add(textBox1.Text);
    Session["survey"] = survey;
    
    //Form2, question2
    var survey = Session["survey"] as List<string>;
    survey.Add(textBox1.Text);
    
    //Form...n... final save
    var survey = Session["survey"] as List<string>;
    for(int i=0; i< survey.Count;i++)
    {
        SaveAnswer("someId", i, survey(i));
    }
