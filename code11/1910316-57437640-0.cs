     static void Main(string[] args)
        {
            string example = "We both arrived at the garage this morning";
            string searchTerm = "ar";
            var intermediateArray = new List<string>();
            var answerArray = new List<string>();
            var tempText = "";
            var exampleArray = example.Split(" ");
            foreach(var word in exampleArray)
            {
      
                if (word.Contains(searchTerm))
                {
                    tempText = "";
                    foreach(var message in intermediateArray)
                    {
                        tempText = tempText + message + " ";
                    }
                    answerArray.Add(tempText);
                    answerArray.Add(word);
                    intermediateArray.Clear();
                    
                }
                else
                {
                    intermediateArray.Add(word);
                }
            }
            // to demonstrate working as intended
            foreach(var text in answerArray)
            {
                Console.WriteLine(text);
            }
        }
