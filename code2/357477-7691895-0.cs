     byte[] delimiter = System.Encoding.Default.GetBytes("++MyDelimited++");
     ms.Write(myFirstFile);
     ms.Write(delimiter);
     ms.Write(mySecondFile);
     ....
     int len;
     do {
        len = ms.ReadByte(buffer, lastOffest, delimiter.Length);
        if(buffer == delimiter)
        {
           // Close and open a new file stream
        }
        // Write buffer to output stream
     } while(len > 0);
