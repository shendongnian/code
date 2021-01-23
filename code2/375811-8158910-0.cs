        string[] addetailsID = new string[20];
        List<int> indices = new List<int>();
        while (indices.Count < 4)
        {
            Random random = new Random();
            int index = random.Next(0, addetailsID.Length);
            if (indices.Count == 0 || !indices.Contains(index))
            {
                indices.Add(index);
            }
        }
 
