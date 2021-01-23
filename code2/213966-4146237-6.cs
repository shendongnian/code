    private static FileResult iCalResult(string ics)
    {
        return new FileStreamResult(WriteCal(ics), "text/calendar");
    }
    private static Stream WriteCal(string ics)
    {
        var content = Encoding.ASCII.GetBytes(ics);
        var stream = new MemoryStream(content);
        return stream;
    }
