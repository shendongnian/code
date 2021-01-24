    // assume these 3 come from user input
    int Lower = 2;
    int Upper = 10;
    int Step = 2;
    if(step < 0){ int temp = Lower; Lower = Upper; Upper = temp;}
    Predicate<int> LoopPred = (i =>
    {
      if(Step < 0)
        return i >= Upper;
      return i <= Upper;
    })
    for(int i=Lower; LoopPred(i); i+=Step)
    {
        Console.Write(i + “ “);
    }
