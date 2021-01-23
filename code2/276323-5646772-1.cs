    try
    {
       //procedure code, possibly hundreds of lines
    }
    catch
    {
       //not really sure what we caught here
       //could be a parameter problem, could be a code problem
       throw new SingleExceptionForAnyParameterIssues();
    }
