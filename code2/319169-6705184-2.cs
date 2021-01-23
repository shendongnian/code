    public class ParserTestHelper
    {
        public static void Test<T>(
             Func<IParser<T>> getParser,
             Func<byte[]> getInput,
             Action<T> checkResult)
        {
            // get parser
            var parser = getParser();
            // get input data
            var input = getInput();
            // parse
            var result = parser.Parse(input, 0);
            // common assertions
            Assert.AreEqual(ParserResultType.Success, result.ResultType);
            Assert.AreEqual(input.Length, result.NextDataOffset);
            // validate results
            checkResult(result.ParsedValue);
        }
    }
