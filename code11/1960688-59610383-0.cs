    public void GiveAnswerA(object sender, EventArgs e)
    {
        if (TextAnswerA.Text == currentQuestions[numberQuestion].CorrectAnswer)
        {
            SetUI();
            score++;
        }
    }
