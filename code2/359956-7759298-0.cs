    string statement = "INSERT INTO tablename ";
    string columns = "(";
    string values = "(";
    for (var i = 0; i < values.Length - 1; i++)
    {
         //if values doesn't contain lift, add it to the statement
         if(!values[i].contains("LIFT"){
              //columnName is a collection of your db column names
              columns += "'"+columnName[i]+"'";
              values += "'"+values[i]+"'";
         }
     }
     columns += ")";
     values += ")";
     statement += columns +" VALUES " + values;
