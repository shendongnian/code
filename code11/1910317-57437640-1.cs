     static void Main(string[] args)
        {
            // sets variables
            string example = "We both arrived at the garage this morning";
            string searchTerm = "ar";
            var intermediateArray = new List<string>();
            var answerArray = new List<string>();
            var tempText = "";
            //splits on " " to isolate words into list.
            var exampleArray = example.Split(" ");
            //loops through each word in original string
            foreach(var word in exampleArray)
            {
                //if word contains search term, add it to the answer array
                if (word.Contains(searchTerm))
                {
                    tempText = "";
                    //loops through words that did not contain the search term 
                    //and adds them as a single string to the answer array.
                    foreach(var message in intermediateArray)
                    {   
                        tempText = tempText + message + " ";
                    }
                    answerArray.Add(tempText);
                    answerArray.Add(word);
                    intermediateArray.Clear();
                    
                }
                //if word does not include search term, add it to the string 
                //that will later be added.//
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
