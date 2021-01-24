    public override void WriteResponseHeaders(OutputFormatterWriteContext ctx )
    {
        var response = ctx.HttpContext.Response;
        response.Headers.Add("Content-Disposition", $"attachment; filename=test.csv");
        response.ContentType = "text/csv";
    }
    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var preamble = _encoding.GetPreamble();
        response.Body.Write(preamble, 0, preamble.Length);
        using (var writer = context.WriterFactory(response.Body, _encoding))
        {
            var csv = new CsvWriter(writer);
            csv.Configuration.HasHeaderRecord = true;
            csv.Configuration.QuoteAllFields =  true;
            csv.WriteRecords((IEnumerable<object>)context.Object);
            await writer.FlushAsync();
        }
    }
