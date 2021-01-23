            string[] addetailsID = new string[20];  // this is the array I want to index into
            // generate the 4 unique indices into addetailsID
            Random random = new Random();
            List<int> indices = new List<int>();
            while (indices.Count < 4)
            {
                int index = random.Next(0, addetailsID.Length);
                if (indices.Count == 0 || !indices.Contains(index))
                {
                    indices.Add(index);
                }
            }
            // now get the 4 random values of interest
            string[] strAdDetailsID = new string[4];
            for (int i = 0; i < indices.Count; i++)
            {
                int randomIndex = indices[i];
                strAdDetailsID[i] = addetailsID[randomIndex];
            }
