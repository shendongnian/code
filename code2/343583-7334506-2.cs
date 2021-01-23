    var splitStrings = stringWithPlus.Split('+');
    for (int i = 0; i < splitStrings.Length; i++) {
       splitStrings[i] = splitStrings[i].Trim();
    }
    string firstHalf = splitStrings[0];
    string secondHalf = splitStrings[1];
