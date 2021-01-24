    using (SqlDataReader reader = cmd.ExecuteReader()) {
        if(reader.HasRows) {
            using (var writer = new StreamWriter(output)) { //<-- writer created once
                while (reader.Read()) {
                    // Some StringBuilder code gets info from the reader
                    // and appends to a string called line
        
                    writer.WriteLine(line);
                }
            }
        } 
    }
