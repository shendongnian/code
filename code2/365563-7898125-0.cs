    public static class Melodie
    {
        private static SpeechLib.SpVoice WomenAgent = new SpeechLib.SpVoice();
        
        public static void AnnounceRestrictionOfAccount()
        {
            WomenAgent.Speak("You're account has been block by the system security", SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);
        }
        public static void SayGoodBye()
        {
            WomenAgent.Speak("Goodbye!");
        }
        public static void WelcomeUser(User userToBeWelcomed)
        {
            string Salutation = ConstructWelcomeSpeech(userToBeWelcomed);
            WomenAgent.Speak(Salutation);
        }
        private static string ConstructWelcomeSpeech(User user)
        {
            string salutation = "Welcome ";
            if (user.Gender == "Male")
            {
                salutation += " Mr. ";
            }
            else if (user.Gender == "Female")
            {
                if (user.CivilStatus != null)
                {
                    if (user.CivilStatus == "Single")
                        salutation += " Ms. ";
                    else
                        salutation += " Mrs. ";
                }
            }
            salutation += user.FirstName + " " + user.LastName;
            return salutation;
        }
        public static void AnnounceMessage(string message)
        {
            WomenAgent.Speak(message);
        }
    }
