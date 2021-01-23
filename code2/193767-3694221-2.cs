    IBusinessRules businessRule = objFactory.GetObject(...some input...)
    ...
    // check if the computable service is supported and print the result
    IComputableRules computable = businessRule as IComputableRules;
    if (computable)
    {
         Console.WriteLine(computable.Calculate());
    }
