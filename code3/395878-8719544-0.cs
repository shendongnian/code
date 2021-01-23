    enum DataFields
        {
            Action = 0,
            CRC = 1,
            Desc = 2,
            Group = 3,
            Name = 4,
            Sell = 5,
            EffDate = 6,
            Whse = 7,
            Whse2 = 8,
            Whse3 = 9,
            Casepack = 10,
            LDU = 11,
            Cube = 12,
            Item = 13,
            UPC = 14,
            Cost = 15,
            Markup = 16,
            OldSell = 17,
            Avail = 18,
            Substitute = 19,
            Poll = 20
        }//enum DataFields
    
        /// <summary>
        /// This will hold the ordinal position of the NameFields within the datafile
        /// </summary>
        enum NameFields
        {
            Code = 0,
            Abrv = 1,
            Name = 2,
            Count = 3
        }//enum NameFields
    
        /// <summary>
        /// This will hold the ordinal position of the values when populating the history table
        /// </summary>
        enum HistoryFields
        {
            CRC = 0,
            EffDate = 1,
            OldSell = 2,
            Sell = 3
        }//enum HistoryFields
        #endregion    
