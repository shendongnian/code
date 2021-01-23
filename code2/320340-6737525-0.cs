        var builder = new StringBuilder();
        string[] data = testString.Split(',');
        for (int i = 0; i < data.Length; i++)
        {
            string[] data1 = data[i].Split(':');
            int num = 0;
            if(Int32.TryParse(data1[1], out num))
            {
                builder.Append(data[i] + ",");
            }
        }
        testString = builder.ToString();
