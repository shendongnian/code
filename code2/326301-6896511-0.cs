    …
    connection.Open();      //  <------------+
    …                       //               |
                            //               |
    while (…)               //               |
    {                       //               |
        …                   //               |
        connection.Open();  // the connection is already open
        …
        connection.Close();
    }
    connection.Close()
