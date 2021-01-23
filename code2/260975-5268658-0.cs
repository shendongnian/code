             TaxonomyFieldValue v = null; // Notsurehowtodothisbit();
            TaxonomySession session = new TaxonomySession(site);
            if (session.TermStores != null && session.TermStores.Count > 0)
            {
                TermStore termStore = session.TermStores[0];
                Term t = termStore.GetTerm(v.TermGuid);
                Term parentTerm = t.Parent;   
            }
