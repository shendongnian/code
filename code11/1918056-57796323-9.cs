    static double? bounds(double? a,double? b,double? c) {
		if(a.HasValue) {
            /* If "a" has value, proceed with Max/Min logic */
    
			if(b.HasValue) {
                /* Calculate Max if "b" Value is defined */
				a = Math.Max(a.Value, b.Value);
			}
			if(c.HasValue) {
                /* Calculate Min if "c" Value is defined */
				a = Math.Min(a.Value, c.Value);
			}
            return a;
		}
		else {
            /* 
            If "a" had no value, return NaN in the same way
            that JavaScripts Min/Max functions would have if
            undefined had been passed in either case 
            */
    		return double.NaN;	
		}
	}
