    class SampleTTS
    {
        static void Main(string[] args)
        {
            try
            {
                // get unprocessed items
                List<String> unProcessedItems = new List<String>();
                unProcessedItems.Add("Kate");
                unProcessedItems.Add("Sam");
                unProcessedItems.Add("Paul");
                unProcessedItems.Add("Violeta");
                foreach (string record in unProcessedItems)
                {
                    // convert text to wav
                    ConvertStringToSpeechWav(record, "c:/temp/" + record + ".wav", Vendor.VOICEWARE, Gender.MALE, Languages.ENGLISH);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
