    StringBuilder builder = new StringBuilder();
    
    // and inside your loop 
    {
        if (blah)
            builder.Append("1");
        else
            builder.Append("0");
    }
    string output = builder.ToString(); // use the final result
