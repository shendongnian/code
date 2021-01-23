        List<Questions> QList = DatabaseConnecter.LoadQuestions();
        Random rndNumber = new Random();
        int randomQuest = rndNumber.Next(30);
        if((QList!=null) && (QList .Count>0))
        {
           lblQuest.Text = QList[randomQuest].QuestionBody;
        }
        else
        {
           lblQuest.Text = "Questions are not loaded!";
        }
        List<Answers> AList = DatabaseConnecter.LoadAnswers();
        int a = 30;
        if((AList!==null) && (AList.Count>0))
        {
           rbAnswer1.Text = AList[a].AnswerA;
        }
        else
        {
           rbAnswer1.Text = "Answers are not loaded!";
        }
