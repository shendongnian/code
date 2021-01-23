    string [] ary = s.Split(" ");
    string [] key;
    string firstname;
    string lastname;
    foreach (string val in ary ) {
        key = val.Split("||");
        if ( key[0] == "FirstName") {
             firstname = key[1];
    }
    if ( key[0] == "LastName") {
       lastname = key[1];
    }
    }
