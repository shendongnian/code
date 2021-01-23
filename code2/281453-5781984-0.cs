    void Query(Agency agency, Citation queryCitation)
    {
        Dictionary<string, Action<Agency, Citation>> QueryMap = new Dictionary<string, Action<Agency, Citation>>
        {
            { "SQL", QueryOracle},
            { "PIC", QueryPic}
        };
        queryCitation.AgencyCode = agency.AgencyCode;
        QueryMap[agency.ClientDb.Type](agency, queryCitation);
    }
