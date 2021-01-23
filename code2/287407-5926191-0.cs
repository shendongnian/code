        private static void Main()
        {
            Speak(VoiceGender.Male);
            Speak(VoiceGender.Female);
        }
        private static void Speak(VoiceGender voiceGender)
        {
            using (var speechSynthesizer = new SpeechSynthesizer())
            {
                var genderVoices = speechSynthesizer.GetInstalledVoices().Where(arg => arg.VoiceInfo.Gender == voiceGender).ToList();
                var firstVoice = genderVoices.FirstOrDefault();
                if (firstVoice == null)
                    return;
                speechSynthesizer.SelectVoice(firstVoice.VoiceInfo.Name);
                speechSynthesizer.Speak("How are you today?");
            }
        }
