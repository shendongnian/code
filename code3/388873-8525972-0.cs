    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
     
    namespace PasswordSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Generated password: {0}", GeneratePassword(12, true));
            }
     
            /// <summary>
            /// Generate a random password
            /// </summary>
            /// <param name="pwdLenght">Password lenght</param>
            /// <param name="nonAlphaNumericChars">Indicates if password will include non alpha-numeric</param>
            /// <returns>Return a password</returns>
            private static String GeneratePassword(int pwdLenght, bool nonAlphaNumericChars)
            {
                // Allowed characters
                String allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
     
                if (nonAlphaNumericChars)
                {
                    // Add non-alphanumeric chars
                    allowedChars += "-&@#%!*$?_";
                }
     
                char[] passwordChars = new char[pwdLenght];
                Random rnd = new Random();
     
                // Generate a random password
                for (int i = 0; i < pwdLenght; i++)
                    passwordChars[i] = allowedChars[rnd.Next(0, allowedChars.Length)];
     
                return new String(passwordChars);
            }
        }
    }
        
