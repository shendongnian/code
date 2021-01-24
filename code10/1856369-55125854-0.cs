    using System;
    using System.Collections;
    using System.Collections.Specialized;
    
    public class SamplesStringCollection
    {
        public static void Main()
        {
            // Creates and initializes a new StringCollection.
            StringCollection myCol = new StringCollection
            {
                "mail1@gmail.com",
                "mail2@gmail.com",
                "mail3@gmail.com",
                "mail4@gmail.com"
            };
    
            if (UserExists(myCol, "mail2@gmail.com"))
            {
                Console.WriteLine("User 2 exists!");
            }
        }
    
        private static bool UserExists(IList myCol, string user)
        {
            return myCol.Contains(user);
        }
    }
