    class GuessTheSecret
    {
        private static readonly string Secret = "Secret";
    
        public static bool IsCorrect(string token)
        {
            return object.ReferenceEquals(token, Secret);
        }
    }
    Console.WriteLine( GuessTheSecret.IsCorrect( "Secret" ) );
