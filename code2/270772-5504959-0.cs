    public void MightFail()
    {
       //obviously your code will do something a little more meaningful
       if(new Random().Next(2) == 0) throw new Exception("I failed");
       return;
    }
    
    public void RunRiskyMethod()
    {
       var failures = 0;
       var successes = 0;
       var totalRuns = 0;
       for(var i=1;i<10000;i++)
       {
           try
           {
              MightFail();
              //if the previous line throws an exception, the below lines will not execute
              successes++;
              Console.WriteLine("Success!");
           }
           catch(Exception) //I didn't name the exception because we don't need its info.
           {
              //These lines ONLY execute if an exception was thrown from within the try block
              failures++;
              Console.WriteLine("Failure!");
           }
           finally
           {
              //this code ALWAYS executes, even if an exception is thrown and not caught
              totalRuns++;
           }
       }
    
       Console.WriteLine(String.Format("{0} Successes, {1} Failures.", successes, failures);
    }
