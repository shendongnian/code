    DateTime lowerBound = new DateTime(2011, 12, 1, 9, 38, 58);
    DateTime upperBound = new DateTime(2011, 12, 1, 9, 49, 58);
    DateTime value = new DateTime(2011, 12, 1, 9, 45, 58);
    // This is an inclusive lower bound and an exclusive upper bound.
    // Adjust to taste.
    if (lowerBound <= value && value < upperBound)
