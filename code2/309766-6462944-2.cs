        List<int> lst = new List<int>();
        lst.Add(1);
        lst.Add(51);
        lst.Add(65);
        lst.Add(786);
        lst.Add(456);
        List<int> lst1 = new List<int>();
        lst1.Add(786);
        lst1.Add(1);
        lst1.Add(456);
        lst1.Add(65);
        lst1.Add(51);
        bool result = false;
        
        if (lst.Count == lst1.Count)
        {
            result = lst.Union(lst1).Count() == lst.Count;
        }
        if (result)
        {
            Response.Write("list are same");
        }
        else
        {
            Response.Write("list are not same");
        }
