        private List<CountType> GetCountTypes(CountType countTypes)
        {
            List<CountType> cts = new List<CountType>();
            foreach (var ct in countTypes.GetFlags())
                cts.Add(ct);
            return cts;
        }
