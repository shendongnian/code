    void CloseButIncorrectAnswer_ShouldFail()
    {
        double computerResult = 20/3;
        double resultToCheck = 6.665;
    
        Assert.IsFalse (IsAnswerCorrect(computerResult, resultToCheck));
    }
    void AnswerMatchesToThreeDP_ShouldBeAccepted()
    {
        double computerResult = 20/3;
        double resultToCheck = 6.666;
    
        Assert.IsTrue (IsAnswerCorrect(computerResult, resultToCheck));
    }
    void CloseWithCorrectRoundingAnswer_ShouldBeAccepted()
    {
        double computerResult = 20/3;
        double resultToCheck = 6.667;
    
        Assert.IsTrue (IsAnswerCorrect(computerResult, resultToCheck));
    }
