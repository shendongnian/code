    public void RequestQuote(string pS, QuoteRequestCallback pQrc) {
        Quote tQ;
        // acquire/release ReadLock inside TryGet
        if (TryGetQuote(pS, out tQ)) {
            pQrc(tQ);
        } else {
            // acquire/release WriteLock inside AddQuote 
            AddQuote(new KeyValuePair(...)); // as above
        })
    }
