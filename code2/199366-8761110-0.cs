    struct HTTP_FILTER_PREPROC_HEADERS
    {
        //
        //  For SF_NOTIFY_PREPROC_HEADERS, retrieves the specified header value.
        //  Header names should include the trailing ':'.  The special values
        //  'method', 'url' and 'version' can be used to retrieve the individual
        //  portions of the request line
        //
        internal GetHeaderDelegate GetHeader {get;set;}
        internal SetHeaderDelegate SetHeader { get; set; }
        internal AddHeaderDelegate AddHeader { get; set; }
        UInt32 HttpStatus { get; set; }               // New in 4.0, status for SEND_RESPONSE
        UInt32 dwReserved { get; set; }               // New in 4.0
    }
