    // make sure you validate input (coming from trusted source?) 
    // before you parse like this.
    string list[] = text.Split(new char [] {' '},4);
    if (list[0] == "Cashpay")
    {
        var username = list[1].SubString(1);
        var amount = list[2];
        var message = list[3];
    }
