    public void CustomFileNameOrderingDemo()
    {
        var files = new[]
        {
            "2017-04-27 Meeting minutes.pdf",
            "2018-11-19 Meeting agenda.pdf",
            "2019-01-12 Meeting minutes.pdf",
            "2018-06-02 Meeting minutes.pdf",
            "2017-12-13 Meeting agenda.pdf",
            "Safeguarding policy.pdf",
            "Welfare policy.pdf",
            "Privacy policy.pdf",
        };
    
        var filesWithDates = FindFilesWithDates().OrderByDescending(f => f).ToList();
        var filesWithoutDates = files.Except(filesWithDates).OrderBy(f => f);
        var result = filesWithDates.Concat(filesWithoutDates);
    
        IEnumerable<string> FindFilesWithDates()
        {
            return files.Where(f => Regex.IsMatch(f, @"^[0-9]{4}-[0-9]{2}-[0-9]{2} "));
        }
    }
