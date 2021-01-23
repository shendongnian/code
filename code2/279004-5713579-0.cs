    System.DateTime time = obtainFromSomewhere(); // allways a date
    System.DateTime? otherTime = obtainFromSomewhereElse(); // null if nothing planned
    if (time == otherTime)
    {
        // match
        ...
    }
