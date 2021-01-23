    class Program
    {
        static void Main(string[] args)
        {
            using (var impersonation = new Impersonation("domain", "username", "password", ImpersonationLevel.Delegation))
            {
                // Do remote operations here.
            }
        }
    }
