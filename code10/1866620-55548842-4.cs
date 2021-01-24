    // Variables to store counts of positive and negative numbers
    int positiveCount = 0;
    int negativeCount = 0;
    // Because we'll be building new arrays, we need to track our
    // position within them, so we create two variables to do that
    int positiveIndex = 0;
    int negativeIndex = 0;
    // loop through once to count the positive and negative numbers
    foreach (var number in numbers)
    {
        if (number > 0)
        {
            ++positiveCount; // same as positiveCount = positiveCount + 1
        }
        else if (number < 0)
        {
            ++negativeCount;
        }
    }
    // now we know how many +ve and -ve numbers we have,
    // we can create arrays to store them
    var positiveNumbers = new int[positiveCount];
    var negativeNumbers = new int[negativeCount];
    // loop through and populate our new arrays
    foreach (var number in numbers)
    {
        if (number > 0)
        {
            positiveNumbers[positiveIndex++] = number;
            // number++ will return the value of number before it was incremented,
            // so it will first access positiveNumbers[0] and then positiveNumbers[1], etc.
           // each time we enter this code block.
        }
        else if (number < 0)
        {
            negativeNumbers[negativeIndex++] = number;
        }
    }
