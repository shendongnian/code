    private void SetUI()
    {
        currentQuestions = stateQuestions;
        numberQuestion = rnd.Next(0, currentQuestions.Count);
        CurrentQuestion.Text = currentQuestions[numberQuestion].QuestionText;
        TextAnswerA.Text = currentQuestions[numberQuestion].Answers[0];
        TextAnswerB.Text = currentQuestions[numberQuestion].Answers[1];
        TextAnswerC.Text = currentQuestions[numberQuestion].Answers[2];
        TextAnswerD.Text = currentQuestions[numberQuestion].Answers[3];
        ResultAnswer.Text = "Punten : "+score.ToString();
    }
