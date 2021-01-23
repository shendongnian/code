    static Stat BuildAverageDateStats<T>(List<T> items, string pname1, string pname2){
        return new Stat { 
            Value = items.Average( c => 
            {
                var ty = c.GetType();
                var pv1 = (dynamic)ty.GetProperty(pname1).GetValue(c,null);
                var pv2 = (dynamic)ty.GetProperty(pname2).GetValue(c,null);
                return pv2 - pv1;
            })
        };
    }
