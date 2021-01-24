    public List<int> GetData(string textBoxData)
    {
            var stringCollection = textBoxData.Split(new[] { Environment.NewLine, "  " }, StringSplitOptions.RemoveEmptyEntries);
            var finalCollection = new List<int>();
            foreach (var s1 in stringCollection)
            {
                int n;
                if (int.TryParse(s1, out n))
                {
                    finalCollection.Add(n);
                }
            }
    }
