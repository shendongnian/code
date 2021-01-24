    static double? bounds(double? a,double? b,double? c) {
		if(b.HasValue) {
			a = Math.Max(a.Value, b.Value);
		}
    
		if(c.HasValue) {
			a = Math.Min(a.Value, c.Value);
		}
    
        return a;
	}
