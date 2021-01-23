        private SPListItemCollection GetItemsByTerm(Term term, SPList list)
        {
            // init some vars    SPListItemCollection items = null;    
            SPSite site = SPContext.Current.Site;     // set up the TaxonomySession    
            TaxonomySession session = new TaxonomySession(site);
            // get the default termstore    TermStore termStore = session.TermStores[0];   
            // If no wssid is found, the term is not used yet in the sitecollection, so no items exist using the term   
            int[] wssIds = TaxonomyField.GetWssIdsOfTerm(SPContext.Current.Site, termStore.Id, term.TermSet.Id, term.Id, false, 1);
            if (wssIds.Length > 0)
            {
                // a TaxonomyField is a lookupfield. Constructing the SPQuery       
                SPQuery query = new SPQuery();
                query.Query = String.Format("<Where><Eq><FieldRef Name='MyTaxonomyField' LookupId='TRUE' /><Value Type='Lookup'>{0}</Value></Eq></Where>", wssIds[0]);
                items = list.GetItems(query);
            }
            return items;
        }
