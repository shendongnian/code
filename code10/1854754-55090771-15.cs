        public static IEnumerable<Dictionary<string, object>> RecordCountResults(
        IEnumerable<Dictionary<string, object>> source,
        IEnumerable<Dictionary<string, object>> target)
        {
            foreach (var sourceDictionary in source)
            {
                var existsInTarget = false;
                foreach (var targetDictionary in target)
                {
                    if (sourceDictionary.IsEqual(targetDictionary))
                    {
                        existsInTarget = true;
                        break;
                    }    
                }
                if (!existsInTarget)
                    yield return sourceDictionary;
            }
        }
