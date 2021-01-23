    public void WriteResults(InputFile file1, InputFile file2, OutputFile resultFile)
    {
        var resultLines =
            from file1Line in file1.GetLines().AsParallel()
            join file2Line in file2.GetLines() on file1Line.Id equals file2Line.Id
            select new OutputLine
            {
                Id = file1Line.Id,
                Value1 = file1Line.Value,
                Value2 = file2Line.Value
            };
        resultFile.WriteLines(resultLines);
    }
