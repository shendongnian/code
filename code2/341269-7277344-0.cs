        static bool CheckFile(string filename)
        {
            const int BUFFER_SIZE = 3002;
            var Reader = new StreamReader(filename, Encoding.ASCII, false, BUFFER_SIZE);
            var buffer = new char[BUFFER_SIZE];
            int offset = 0;
            int bytesRead = 0;
            while((bytesRead = Reader.Read(buffer, offset, BUFFER_SIZE)) > 0)
            {
                if(bytesRead != BUFFER_SIZE 
                    || buffer[BUFFER_SIZE - 2] != '\r' 
                    || buffer[BUFFER_SIZE - 1] != '\n')
                {
                    //the file does not conform
                    return false;
                }
                offset += bytesRead;
            }
            return true;
        }
