        static void PrintIsInAdministrators()
        {
            // There are many ways to get a principle... this is one.
            System.Security.Principal.IPrincipal principle = System.Threading.Thread.CurrentPrincipal;
            bool isInRole = principle.IsInRole("MyDomain\\MyRole");
            Console.WriteLine("I {0} an Admin", isInRole ? "am" : "am not");
        }
