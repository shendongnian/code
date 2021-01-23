    public void QuestionTimerSetup()
    {
      MajorMinorTimer timerQuestion = 
        new MajorMinorTimer
          (
            1,
            5,
            // major interval action
            (SecsRemaining) => 
              {
                tblockQuizStatus.Text = 
                  string.Format("There are {0} seconds remaining.", SecsRemaining);               
              },
            // minor interval action
            () => 
              {
                if (NoMoreQuestions)
                {
                  tblockQuizStatus.Text = 
                    "Time's up!  This completes the quiz!";
                  HandleEndOfQuiz();
                }
                else
                {
                  tblockQuizStatus.Text = 
                    "Time's up!  Press Enter to continue to next question.";
                }
              },
            // timer cancel check function
            () => 
              IsEndOfQuizHandled()
          ); 
    }
    
