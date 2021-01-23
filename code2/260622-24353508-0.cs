        /*
         * convert magic numbers created by:
         *    (153*month - 457)/5) 
         * into an explicit array of integers
         */
        int[] CumulativeDays = new int[]
        {
            -92   // Month = 0	(Should not be accessed by algorithm)
          , -61   // Month = 1	(Should not be accessed by algorithm)
          , -31   // Month = 2	(Should not be accessed by algorithm)
          ,   0   // Month = 3	(March)
          ,  31   // Month = 4	(April)
          ,  61   // Month = 5	(May)
          ,  92   // Month = 6	(June)
          , 122   // Month = 7	(July)
          , 153   // Month = 8	(August)
          , 184   // Month = 9	(September)
          , 214   // Month = 10	(October)
          , 245   // Month = 11	(November)
          , 275   // Month = 12	(December)
          , 306   // Month = 13	(January, next year)
          , 337   // Month = 14	(February, next year)
        };
