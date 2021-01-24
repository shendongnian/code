        foreach (string arg in args)
        {
            string[] parts = arg.Split('=');
            if (parts.Length > 1)
            {
                //results[parts[0]] = parts[1];
				results.Add(parts[0], parts[1]);
                continue;
            }
            else
            {
                results.Add("GetUser", arg);
            }
        }
