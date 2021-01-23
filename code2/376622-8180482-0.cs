    public IEnumerable<Tuple<T,double>> Extend(IEnumerable<Tuple<T,double>> collection, 
       T term,double value)
    {
       foreach (var x in collection.Where(x=>!x.Item1.Equals(term)))
       {
         yield return x;
       }
       yield return Tuple.Create(term,value);
    }
