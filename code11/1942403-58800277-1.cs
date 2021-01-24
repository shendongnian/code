    List<Color> color = output
        .Select(o => new Color
        {
            ColorId = o.ColorId,
            ColorName = o.ColorName,
            shortName = o.ShortName,
        })
        .ToList();
