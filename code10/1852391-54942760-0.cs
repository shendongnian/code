    .Include(e => e.SharedCar.Vignette
        .Select(v => new
        {
            v.Id,
            v.GUID,
            v.CountryName,
            v.CountryCode
        })
    )
