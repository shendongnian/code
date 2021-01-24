        public bool Process(string connString, string sql, string resumeFromPosition = null)
    {
        using ()// init your connection, command, reader
        {
            if (resumeFromPosition != null)
            {
                while (dr.Read() && dr.ToPositionString() != resumeFromPosition)
                {
                    // skipping already processed records
                }
            }
            while (dr.Read)
            {
                // Do your complex processing
                // You can do this every N records if accuracy is not critical
                lastProcessedPosition = dr.ToPositionString();
            }
        }
        return true;
    }
