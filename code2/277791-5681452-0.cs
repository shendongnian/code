    var intArray = new List<int>(){1,2,3,4};
    if (intArray.Count > 0) {
        var query = "SELECT * FROM table WHERE id IN (";
        for (int i = 0; i < intArray.Count; i++) {
            //Append the parameter to the query
            //Note: I'm not sure if mysql uses "@" but you can replace this if needed
            query += "@num" + i + ",";
            //Add the value to the parameters collection
            ...connection.Command.Parameters.AddWithValue("num" + i, intArray[i]);
        }
        //Remove the last comma and add the closing bracket
        query = query.Substring(0, query.Length - 1) + ");";
        //Execute the query here
    }
