    public void QuestionTimerSetup()
    {
      // sets up a timer to fire a minor tick every second
      // with a major interval of 5 seconds
      MajorMinorTimer timerQuestion = new MajorMinorTimer(1, 5); 
    
      timerQuestion.onTick += 
        new delegateMajorMinorTimerTick(QuestionControl_QuestionTimerTick);
    }
    
    // ...
    
    public void QuestionControl_OnTick(int TimeRemaining_sec, ref bool CancelTimer)
    {
      if (TimeRemaining_sec > 0)
      {
        tblockQuizStatus.Text = 
          string.Format("There are {0} seconds remaining.", TimeRemaining_sec);
      }
      else
      {
        // just for an example
        if (NoMoreQuestions)
        {
           CancelTimer = true;
           HandleEndOfQuiz();
           tblockQuizStatus.Text =
             "Time's up!  The quiz is complete!";
        }
        else
        {
           tblockQuizStatus.Text = 
             "Time's up!  Press Enter to continue to the next problem.";
        }
      }
    }
