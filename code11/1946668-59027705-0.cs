csharp
    public sealed class JsonDataSourceAttribute : DataAttribute
    {
        public string InputFilePath { get; }
        /// <summary>
        /// Retrieves a collection of context data
        /// </summary>
        /// <param name="inputFilePath">Json source file path</param>
        public JsonDataSourceAttribute(string inputFilePath)
        {
            this.InputFilePath = inputFilePath;
        }
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }
            var inputfile = Path.IsPathRooted(this.InputFilePath)
                ? this.InputFilePath
                : Path.Combine(Directory.GetCurrentDirectory(), this.InputFilePath);
            if (!File.Exists(inputfile))
            {
                throw new ArgumentException($"Input file not found at '{inputfile}'.");
            }
            return this.LoadFileData(inputfile, this.EnumMap);
        }
        (...)
    }
By moving the file existence check to the constructor, I was able to get what I wanted.
csharp
        public JsonDataSourceAttribute(string inputFilePath)
        {
            var inputfile = Path.IsPathRooted(inputFilePath)
                ? inputFilePath
                : Path.Combine(Directory.GetCurrentDirectory(), inputFilePath);
            if (!File.Exists(inputfile))
            {
                throw new ArgumentException($"Input file not found at '{inputfile}'.");
            }
            this.InputFilePath = inputfile;
        }
This is not the "find the root cause" answer, but I guess it wouldn't be possible since the original exception is omitted on `Xunit.Sdk.DataAttribute`.
