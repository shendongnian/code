        private static bool TryLogin(int attempts = 3) {
          for (int i = 0; i < attempts; ++i) {
            Console.WriteLine("Enter Username");
            string userid = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            if (userid == "Daniel" && password == "polle")            
              return true;
          }
          return false; 
        }
