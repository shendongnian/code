public void FunctionHandler(object input, ILambdaContext context)
{
    try
    {
        CreateException();
    }
    catch (Exception e)
    {
        // Handle your 'uncaught' exceptions here and/or rethrow if needed
        Console.WriteLine(e);
        throw;
     }
}
You would likely want to rethrow so that:
 1. AWS will retry the function again, then you can send it DeadLetterQueue after X retries
 2. You get the exception in your CloudWatch Logs
