    var FAQfor3Months = new Dictionary<string, int>();
    var FAQfor4to12Months = new Dictionary<string, int>();
    var FAQfor12plusMonths = new Dictionary<string, int>();
    foreach (Activity call in CallsForProperty) {
        if ( /*call is in 3 months*/ ) {
            //do some unrelated stuff
            FAQfor3Months.TryGetValue(call.callQuestion, out int count);
            FAQfor3Months[call.callQuestion] = count+1;
        }
    }
    var top3ThreeMonthFaqs = FAQfor3Months.OrderByDescending(kvp => kvp.Value).Take(3).Select(kvp => kvp.Key).ToList();
