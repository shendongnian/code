    var inne = false;
    if (!bool.TryParse(vektor[3], out inne))
    {
        // parsing failed, handle the error here
    }
    else
        Biblotek.Add(new Novellsamling(vektor[0], vektor[1], vektor[2], inne));
