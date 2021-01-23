    IEnumerable<PCMessages> messages = LintMessages;
    
    foreach (var filter in FilterList.Where(f => f.applied)) {
        messages = messages.Where (
            // build lambda expression depending on filter
        );
    }
    
    var FiltLintMessages = messages.ToList ();
