        public void UpdateAudit(Int32 rpaID, Int32 auditID)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["RPADB"].ConnectionString;
            var dataContext = new DataContext(new SqlConnection(ConnectionString));
            RPAHeaderEntity RPAHeaderEntitytoUpdate = dataContext.GetTable<RPAHeaderEntity>().Single(p => p.RPAID == rpaID);
            RPAHeaderEntitytoUpdate.RPAStatusID = auditID;
            RPAHeaderEntitytoUpdate.XMLData = new XDocument(RPAHeaderEntitytoUpdate.XMLData);**
            dataContext.SubmitChanges();
        }
