    public class ABTest
    {
        [JsonProperty(Required = Required.Always)]
        public ulong CountOfAs { get; private set; }
        [JsonProperty(Required = Required.Always)]
        public ulong CountOfBs { get; private set; }
        [JsonProperty(Required = Required.Always)]
        public ulong TotalCount { get; private set; }
        [JsonConstructor]
        public ABTest(ulong countOfAs, ulong countOfBs, ulong totalCount)
        {
            if (totalCount != countOfAs + countOfBs)
                throw new ArgumentException(nameof(totalCount));
            CountOfAs = countOfAs;
            CountOfBs = countOfBs;
            TotalCount = totalCount;
        }
    }
