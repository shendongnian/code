    public class FirstCodeHandlerClass: ICodeHandler
    {
        public void HandleCode(string code)
        {
            parse = ParseCode(code);
            dbValue = GetSomethingFromDB(parse);
            if (OtherCheck1(dbValue)
            {
                // Launch the Pay Taxes project.
            }
            else if (OtherCheck2(dbValue)
            {
                // Launch the Uploaded File project
            }
            else
            {
                // Schedule Something or other project
            }
        }
    }
