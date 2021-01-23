     SqlConnection pubsConn = new SqlConnection("Data Source=localhost;Integrated Security=SSPI;Initial Catalog=pubs;");
        SqlCommand logoCMD = new SqlCommand("SELECT pub_id, logo FROM pub_info", pubsConn);
        
        FileStream fs;                          // Writes the BLOB to a file (*.bmp).
        BinaryWriter bw;                        // Streams the BLOB to the FileStream object.
        
        int bufferSize = 100;                   // Size of the BLOB buffer.
        byte[] outbyte = new byte[bufferSize];  // The BLOB byte[] buffer to be filled by GetBytes.
        long retval;                            // The bytes returned from GetBytes.
        long startIndex = 0;                    // The starting position in the BLOB output.
        
        string pub_id = "";                     // The publisher id to use in the file name.
        
        // Open the connection and read data into the DataReader.
        pubsConn.Open();
        SqlDataReader myReader = logoCMD.ExecuteReader(CommandBehavior.SequentialAccess);
        
        while (myReader.Read())
        {
          // Get the publisher id, which must occur before getting the logo.
          pub_id = myReader.GetString(0);  
        
          // Create a file to hold the output.
          fs = new FileStream("logo" + pub_id + ".bmp", FileMode.OpenOrCreate, FileAccess.Write);
          bw = new BinaryWriter(fs);
        
          // Reset the starting byte for the new BLOB.
          startIndex = 0;
        
          // Read the bytes into outbyte[] and retain the number of bytes returned.
          retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
        
          // Continue reading and writing while there are bytes beyond the size of the buffer.
          while (retval == bufferSize)
          {
            bw.Write(outbyte);
            bw.Flush();
        
            // Reposition the start index to the end of the last buffer and fill the buffer.
            startIndex += bufferSize;
            retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
          }
        
          // Write the remaining buffer.
          if(retval > 0) // if file size can divide to buffer size
              bw.Write(outbyte, 0, (int)retval - 1);
          bw.Flush();
        
          // Close the output file.
          bw.Close();
          fs.Close();
        }
        
        // Close the reader and the connection.
        myReader.Close();
        pubsConn.Close();
