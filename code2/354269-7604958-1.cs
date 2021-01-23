    public static class ChallengeFactory
    {
        public class Challenge
        {
            public int Difficulty { get; set; }
            public bool IsChecked { get; set; }
            public string Title { get; set; }
            public string Question { get; set; }
            public Uri ImageSource { get; set; }
            public bool Visible { get; set; }
            public string ResourceValue { get; set; }
            public string Answer { get; set; }
        
            private Challenge(int difficulty, bool isChecked, string title, string question, Uri imageSource, bool visible, string resourceValue, string answer)
            {
                // assign each of the arguments to the instance properties
            }
        }
    
        public static Challenge GetChallenge(int challengeNumber)
        {
            switch(challengeNumber)
            {
                case 1:
                    return new Challenge(20, false, "Chicken or Egg?", "Can you answer the ancient question: Which came first the chicken of the egg?", new Uri("Images/Challenge1.png", UriKind.Relative), true, "Resource: Brain Games", "The Egg...");
                break;
                case 2:
                    // new challenge for challenge #2
                break;
                case 3:
                    // new challenge for challenge #3
                break;
            }
        }
    }
