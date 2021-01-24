    public string Food  // <-- return type should be string, not List<string>
    {
        get {
            string aliments = "";
            foreach (string aliment in Food)
            {
                aliments += $"{aliment} ";
            }
            return aliments;
        }
    }
