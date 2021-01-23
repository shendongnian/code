        string selectedSpeakData = "Sample Text Sample Text Sample Text Sample Text Sample Text";
        private SpeechSynthesizer speech;
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
                {
                    speech= new SpeechSynthesizer();
                    speech.SpeakProgress += new EventHandler<System.Speech.Synthesis.SpeakProgressEventArgs>(speech_SpeakProgress);
                    speech.SpeakAsync(selectedSpeakData);
                }
        
        void speech_SpeakProgress(object sender, System.Speech.Synthesis.SpeakProgressEventArgs e)
                {
                    if (speech.Volume != Convert.ToInt32(sliderVolume.Value) || speech.Rate != Convert.ToInt32(sliderRate.Value))
                    {
                        speech.Volume = Convert.ToInt32(sliderVolume.Value);
                        speech.Rate = Convert.ToInt32(sliderRate.Value);
                        selectedSpeakData = selectedSpeakData.Remove(0, e.CharacterPosition);
                        speech.SpeakAsyncCancelAll();
                        speech.SpeakAsync(selectedSpeakData);
                    }
                }
