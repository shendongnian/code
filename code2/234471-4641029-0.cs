    using System.Threading;
    using System.Security.Principal;
    namespace StackOverflow_Demo
    {
      class Program
      {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal currentPrincipal = (WindowsPrincipal) Thread.CurrentPrincipal;
            if (currentPrincipal.IsInRole("Administrators"))
            {
                // continue programm
            }
            else
            {
                // throw exception/show errorMessage - exit programm
            }
         }
       }
     }
