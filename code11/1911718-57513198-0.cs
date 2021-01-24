    public class INumberList : List<string>
    { 
        public List<int> GetNumberList()
        {
            List<int> numberList = new List<int>();
            for (int i = 0; i < this.Count; i++)
            {
                numberList.Add(GetIntFromString(this[i]));
            }
            return numberList;
        } 
        public INumberList ExcludeIndex(string prefix, string suffix)
        {
            for (int i = 0; i < this.Count; i++)
            { 
                if (this[i].StartsWith(prefix) && this[i].EndsWith(suffix))
                {
                    //remove non needed indexes
                    this.RemoveAt(i);
                }
            }
            return this;
        }
        public static int GetIntFromString(String input)
        {
            // Replace everything that is no a digit.
            String inputCleaned = Regex.Replace(input, "[^0-9]", "");
            int value = 0;
            // Tries to parse the int, returns false on failure.
            if (int.TryParse(inputCleaned, out value))
            {
                // The result from parsing can be safely returned.
                return value;
            }
            return 0; // Or any other default value.
        }
    }
