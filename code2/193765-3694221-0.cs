    IBase algorithm = algorithmFactory.GetAlgorithm(...some input...)
    ...
    // check if the computable service is supported and print the result
    IComputableAlgorithm computable = algorithm as IComputableAlgoritm;
    if (computable)
    {
         Console.WriteLine(computable.Calculate());
    }
