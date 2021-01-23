    var numerOfT = context.Students.Where(x => x.StudID == 123 && x.Date.Month == studentMonth).Sum(x => x.I.ToInt() + x.II.ToInt() + ... + x.VIII.ToInt());
    
    
            public static int ToInt(this bool value)
            {
                return value ? 1 : 0;
            }
