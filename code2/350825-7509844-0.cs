    while (SQLRD.Read())
    {
         data += SQLRD[0].ToString() + ",";
                       //              ^^^ note the change from '\n' to ','
         data += SQLRD[1].ToString() + ",";
         data += SQLRD[2].ToString() + ",";
         ...
         data += SQLRD[7].ToString(); // final column doesn't need a ','
         data += "\n"; // final line separator for the entire row
    }
