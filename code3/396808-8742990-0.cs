    static void Main() {
        var lstTest = new List<SampleItem>() { 
            new SampleItem(){ QCD = "Q1" ,  CCD = "C1" , ITYPE = "B"} ,
            new SampleItem(){ QCD = "Q1" ,  CCD = "C2" , ITYPE = "B"} ,
            new SampleItem(){ QCD = "Q1" ,  CCD = "C1" , ITYPE = "A"} ,
            new SampleItem(){ QCD = "Q1" ,  CCD = "C2" , ITYPE = "A"} ,
            new SampleItem(){ QCD = "Q1" ,  CCD = "C3" , ITYPE = "A"} ,
            new SampleItem(){ QCD = "Q1" ,  CCD = "C1" , ITYPE = "B"} ,
            new SampleItem(){ QCD = "Q1" ,  CCD = "C2" , ITYPE = "B"} ,
        };
        foreach(var group in lstTest.Split(x => new { x.QCD, x.ITYPE})) {
            Console.WriteLine("{0}, {1}", group[0].QCD, group[0].ITYPE);
            foreach(var item in group) {
                Console.WriteLine("\t{0}", item.CCD);
            }
        }
    }
    public static IEnumerable<TSource[]> Split<TSource, TValue>(
        this IEnumerable<TSource> source, Func<TSource, TValue> selector)
    {
        var comparer = EqualityComparer<TValue>.Default;
        using(var iter = source.GetEnumerator()) {
            if(iter.MoveNext()) {
                List<TSource> buffer = new List<TSource>();
                buffer.Add(iter.Current);
                TValue groupValue = selector(iter.Current);
                while(iter.MoveNext()) {
                    var currentItem = iter.Current;
                    var currentValue = selector(currentItem);
                    if(!comparer.Equals(groupValue, currentValue)) {
                        var arr = buffer.ToArray();
                        buffer.Clear();
                        yield return arr;
                        groupValue = currentValue;
                    }
                    buffer.Add(currentItem);
                }
                yield return buffer.ToArray();
            }
        }
    }
