    var now = DateTime.Now;
    var altData = myData
        .Select(data => new
        {
            Year = (data.Expiration.Year - DateTime.Now.Year) + 1,
            data.Name,
            Value = data.Quantity * data.Price,
        });
    var years = Enumerable.Range(1, 20);
    var names = myData.Select(data => data.Name).Distinct();
    var query = from Year in years
                from Name in names
                join data in altData
                    on new { Year, Name }
                    equals new { data.Year, data.Name }
                    into joined
                from data in joined.DefaultIfEmpty()
                select new
                {
                    Year,
                    Name,
                    Value = data != null ? data.Value : 0M,
                };
