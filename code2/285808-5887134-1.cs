    public bool IsSequential(this IEnumerable<DateTime> sequence) {
        Contract.Requires(sequence != null);
        var e = sequence.GetEnumerator();
        if(!e.MoveNext()) {
            // empty sequence is sequential
            return true;
        }
        int previous = e.Current.Date;
        while(e.MoveNext()) {
            if(e.Current.Date != previous.AddDays(1)) {
                return false;
            }      
            previous = e.Current.Date;
        }
        return true;
    }
