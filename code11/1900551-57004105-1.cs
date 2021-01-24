    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary to hold the animal by id (id is assumed to be the index in the original array.
            var result = new Dictionary<int, Animal>();
        
            foreach (var answer in animals)
            {
                // Parse the value between the "[" and "]" if the question id contains the word "animals" into an int for the dictionary key.
                if (answer.QuestionId.Contains("animals") && int.TryParse(answer.QuestionId.Substring(answer.QuestionId.IndexOf('[') + 1, 1), out var id))
                {
                    if (!result.TryGetValue(id, out var value))
                    {
                        value = new Animal();
                        result[id] = value;
                    }
                    
                    // Check if the answer is to "howold" o "howbig" and construct the animal object.
                    if (answer.QuestionId.Contains("howold"))
                    {
                        value.Age = answer.Value;
                    }
                    else if (answer.QuestionId.Contains("howbig"))
                    {
                        value.Size = answer.Value;
                    }
                    else
                    {
                        Debug.Assert(false, "Unidentified animal answer");
                    }
                 }
              }
              // Number of animals in the array:
              var animalCount = result.Keys.Count;
           }
        }
     
        // Define a class for animal information.
        public class Animal
        {
            public int Id { get; set; }
        
            public int Age { get; set; }
        
            public int Size { get; set; }
        }
     }
