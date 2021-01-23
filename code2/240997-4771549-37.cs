    var pool = new Pool
    {
        PickListGenerator = new SportsPicklistGenerator(),
        IsQuestionIsAnswerableDeterminer = new GameQuestionIsAnswerableDeterminer()
    };
    pool.Execute();
    
    // reuse the same class logic in Pool class in Execute method
    pool.PickListGenerator = new GamePickListGenerator();
    pool.Execute();
    
    // reuse the same class logic in Pool class in Execute method
    pool.IsQuestionIsAnswerableDeterminer = new RoundQuestionIsAnswerableDeterminer();
    pool.Execute();
