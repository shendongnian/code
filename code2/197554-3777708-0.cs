            string[] myTests = { "I", "am", "Steven", "King" };
            string data = "I am Steven";
            Dictionary<int, int> testResults = new Dictionary<int,int>();
            for (int idx = 0; idx < myTests.Length; ++idx)
            {
                int strIndex = data.IndexOf(myTests[idx], StringComparison.InvariantCultureIgnoreCase);
                testResults[idx] = strIndex;
            }
            // Each test index in the results dictionary that is >= 0 is a match, -1 is a failed match
