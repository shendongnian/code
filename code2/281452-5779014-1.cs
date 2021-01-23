    public void Query(Agency agency, Citation queryCitation) {
            queryCitation.AgencyCode = agency.AgencyCode;
    
            switch (agency.ClientDb.Type) {
                case "SQL":
                    QueryOracle(agency, queryCitation);
                    break;
                case "PIC":
                    QueryPick(agency, queryCitation);
                    break;
            }
        }
