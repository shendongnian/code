    Dictionary<Elements, double> dic = new Dictionary<Elements, double>();
    for (int i = 0; i < listDouble.Count; i++)
    {
    dic.Add(listElements[i],listDouble[i]);
    }
    var newListElements=dic.OrderBy(x => x.Value).Select(x=>x.Key).ToList();    
    
