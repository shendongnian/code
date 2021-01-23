    public List<Tuple<T,double>> Replace(List<Tuple<T,double>> collection, T term,double value)
    {
       var newItem = new List<Tuple<T,double>>();
       newItem.Add(new Tuple<T,double>(term,value));
       return collection.Where(x=>!x.Item1.Equals(term)).Concat(newItem).ToList();
    }
