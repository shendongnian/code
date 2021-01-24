    public static void ProcessFile()
    {
        using (Open_file_1_for_reading)
        {
            if (condition)
            {
                using (Open_memory_stream_for_writing)
                {
                    // ...
                }
            }
        }
    }
