    using (var reader = new CsvHelper.CsvReader(File.OpenText(inputFile)))
    {
        reader.Configuration.TrimOptions = CsvHelper.Configuration.TrimOptions.Trim;
        var query =
            from r in reader.GetRecords(new { FilmMaker = "", MovieTitle = "", EndDate = "" })
            let date = DateTime.ParseExact(r.EndDate, "yyyyMMdd", default)
            where date > new DateTime(2019, 12, 10)
            orderby date
            group r by r.FilmMaker into g
            select g.First();
        var dict = query.ToDictionary(
            r => r.MovieTitle,
            r => new { r.FilmMaker, r.EndDate }
        );
        // do stuff with dict
    }
