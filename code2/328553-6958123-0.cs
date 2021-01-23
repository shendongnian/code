    // The stream of assets
    IObservable<Asset> assets = ...
    // The stream of each asset projected to a DebugAnswer
    IObservable<DebugAnswer> debugAnswers = from asset in assets
                                            select new DebugAnswer { result = 100 };
    // Subscribe the DebugListener to receive the debugAnswers
    debugAnswers.Subscribe(DebugListener);
 
    // The stream of each asset projected to an Anwer
    IObservable<Answer> answers = from asset in assets
                                  select new Answer { bla = 200 };
    // Subscribe the AnswerListener to receive the answers
    answers.Subscribe(AnswerListener);
