    while (myReader.Read())
    {  // <<- here
        Console.WriteLine(myReader["Username"].ToString());
        Console.WriteLine(myReader["Item"].ToString());
        Console.WriteLine(myReader["Amount"].ToString());
        Console.WriteLine(myReader["Complete"].ToString());
    }  // <<- here
