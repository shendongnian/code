    public class ExampleTest
    {
        [Theory]
        [InlineData ("somefile", 3, 332, 354)]
        [InlineData ("anotherfile", 3, 290, 337)]
        [InlineData ("thirdfile", 4, 310, 304)]
        public void FileParseOutputIsCorrect ( string fileName, int parameter, int resultA, int resultB )
        {
            //conditional check only necessary if you want to stop parsing in future test runs
            if ( !fileName.Parsed )
            {
                var fileParseResult = FileParser.ParseFile ( fileName, parameter );
                Assert.Equal ( fileParseResult[0], resultA );
                Assert.Equal ( fileParseResult[1], resultB );
            }
            else
            {
                Console.WriteLine ( $"Already parsed {fileName}" );
            }
        }
    }
