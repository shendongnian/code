    var subValues = someValues
        .Where(v => v.IsMumsHairGreenToday)
        .SelectMany(v => v.SubValues)
        ;
    foreach(var subValue in subValues)
    {
        // ...
        break;
    }
