            OleDbParameter[] oledbParams = new OleDbParameter[6];
            //To be added in proper order.
            oledbParams[0] = new OleDbParameter("PN1", "1001");
            oledbParams[1] = new OleDbParameter("PN2", "1002");
            .
            .
            oledbParams[6] = new OleDbParameter("DateValue", DateTime.Now.Date);
            foreach (var p in oledbParams)
            {
                command.Parameters.Add(p);
            }
