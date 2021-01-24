        public static IEnumerable<Dictionary<string, object>> RecordCountResults(
            IEnumerable<Dictionary<string, object>> source,
            IEnumerable<Dictionary<string, object>> target)
        {
            foreach(var sourceDictionary in source)
            {
                yield return sourceDictionary
                    .Where(
                        skv => !target
                                .SelectMany(td => td) // flatten target list dictionaries
                                .Any( // check if source key exists and if it has the same value
                                    tkv => tkv.Key == skv.Key
                                    && tkv.Value.Equals(skv.Value))
                    )
                    .ToDictionary(
                        x => x.Key,
                        x=> x.Value);
            }
        }
