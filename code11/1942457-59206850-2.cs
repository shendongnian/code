public static class Func 
{
   [DisplayName("JobID: {0} => [{1}:{2}]")]
   public static void Execute(long requestID, string stepName, string stepLocation)
   {
      // do work here
   }
}
// above method is called by the background.enqueue call
BackgroundJob.Enqueue(() => Func.Execute(longId, stepName, stepLocation);
that seems to provide the information relevant to the job that is executed.
