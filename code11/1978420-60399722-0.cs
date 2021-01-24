    public List<string> SplitList = new List<string>();
        public void SplitByRow()
        {
            var userInput = Console.ReadLine();
            string[] splitArray = userInput != null ? userInput.Split(' ') : null;
            SplitList = splitArray != null ? splitArray.ToList() : null;
        }
