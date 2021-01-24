    var l = new List<Tuple<Root, Child>>();
    foreach(var p in context.Roots.Include(x => x.Children))
    {
        foreach(var c in p.Children)
        {
            if(c.Code == "A100")
            {
                l.Add(new Tuple(p,c));
                break;
            }
        }
    }
