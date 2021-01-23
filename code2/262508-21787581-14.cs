        public void GetCompanies() {
            ECCDestinationConfig cfg = new ECCDestinationConfig();
            RfcDestinationManager.RegisterDestinationConfiguration(cfg);
            
            RfcDestination dest = RfcDestinationManager.GetDestination("mySAPdestination");
            RfcRepository repo = dest.Repository;
            IRfcFunction testfn = repo.CreateFunction("BAPI_COMPANYCODE_GETLIST");
            testfn.Invoke(dest);
            var companyCodeList = testfn.GetTable("COMPANYCODE_LIST");
            // companyCodeList now contains a table with companies and codes
        }
