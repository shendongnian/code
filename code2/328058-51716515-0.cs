    public enum ConnectionState
        {
            //
            // Summary:
            //     The connection is closed.
            Closed = 0,
            //
            // Summary:
            //     The connection is open.
            Open = 1,
            //
            // Summary:
            //     The connection object is connecting to the data source. (This value is reserved
            //     for future versions of the product.)
            Connecting = 2,
            //
            // Summary:
            //     The connection object is executing a command. (This value is reserved for future
            //     versions of the product.)
            Executing = 4,
            //
            // Summary:
            //     The connection object is retrieving data. (This value is reserved for future
            //     versions of the product.)
            Fetching = 8,
            //
            // Summary:
            //     The connection to the data source is broken. This can occur only after the connection
            //     has been opened. A connection in this state may be closed and then re-opened.
            //     (This value is reserved for future versions of the product.)
            Broken = 16
        }
