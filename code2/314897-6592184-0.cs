    DateTime inputDate;
    if(!DateTime.TryParse(inputString, out inputDate))
        throw new ArgumentException("Input string not in the correct format.");
    if(inputDate.Date == DateTime.Now.Date) {
        // Same date!
    }
