        List<string> result = new List<string>();
        for (var i = 0; i < terms.GetLength(0); i++)
        {
            for (var j = 0; j < terms.GetLength(1); j++)
            {
                result.Add(terms[i, j]);
            }
        }
        string output = string.Join(",", result);
