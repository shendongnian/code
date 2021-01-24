    public class ABTest
    {
        [JsonProperty(Required = Required.Always)]
        public ulong CountOfAs { get; }
        [JsonProperty(Required = Required.Always)]
        public ulong CountOfBs { get; }
        [JsonProperty(Required = Required.Always)]
        public ulong TotalCount { get; }
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
