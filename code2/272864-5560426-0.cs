    // Note: Name boolean variables like they are a question
    bool isValidDecoding = true;
    foreach (string decodedValue in arrayOfvalues)
    {
        isValidDecoding &= !decodedValue.Contains("invalid")
            && !decodedValue.Contains("length")
            && !decodedValue.Contains("bad");
    }
