    var numbers = new StringBuilder();
    string[] coordinatesVal = coordinateTxt
        .Trim()
        .Split(new string[] { ",0" }, StringSplitOptions.None);
    for (int i = 0; i < coordinatesVal.Length - 1; i++) {
        numbers
            .Append(coordinatesVal[i].Trim().Replace(',', ' '))
            .Append(", ");
    }
    numbers.Length -= 2;
