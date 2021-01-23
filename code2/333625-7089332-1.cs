    //I would place it inside inner-most using block, but nothing wrong placing it outside
    try{
        connection.open();
        command.Parameters.AddWithValue("@cruiseId", CruiseID);
         command.Execute();
    }
    //this catches ALL exceptions, regardless of source. Better narrow this down with
    //some specific exception, like SQLException or something like that
    catch (Exception e){
        return false; //or whatever you need to do
    }
