    public static void Read(int length)
        {
            StringBuilder resultAsString = new StringBuilder();
            using (MemoryMappedFile memoryMappedFile = MemoryMappedFile.CreateFromFile(@"D:\_Profession\Projects\Parto\HotelDataManagement\_Document\Expedia_Rapid.jsonl\Expedia_Rapi.json"))
            using (MemoryMappedViewStream memoryMappedViewStream = memoryMappedFile.CreateViewStream(0, length))
            {
                for (int i = 0; i < length; i++)
                {
                    //Reads a byte from a stream and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
                    int result = memoryMappedViewStream.ReadByte();
                    if (result == -1)
                    {
                        break;
                    }
                    char letter = (char)result;
                    resultAsString.Append(letter);
                }
            }
        }
