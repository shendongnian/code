            String path = "A:B:C";
            String roleNeeded = "X";
            List<String> roles = new List<string>() { "A::Z", "A::Y", "A:B::X" };
            List<String> pathStep = new List<string>();
            pathStep = path.Split(':').ToList();
            String lookupPath = String.Empty;
            String result = String.Empty;
            pathStep.ForEach( s =>
            {
                lookupPath += s;
                if (roles.Contains(lookupPath + "::" + roleNeeded))
                {
                    result = lookupPath + "::" + roleNeeded;
                }
                lookupPath += ":";
            });
            if (result != String.Empty)
            {
                // result is Good_Path::Role
            }
