        private static bool TryLogin(int attempts = 3) {
          // Try attempts times
          for (int i = 0; i < attempts; ++i) {
            Console.WriteLine("Enter Username");
            string userid = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            // if both userid and password are correct return true - login succeed - true
            if (userid == "Daniel" && password == "polle")            
              return true;
          }
          // all attempts are exhausted, login failed - false
          return false; 
        }
