        List<Guid> lst = new List<Guid>();
        List<Guid> lst1 = new List<Guid>();
        bool result = false;
        if (lst.Count == lst1.Count)
        {
            for (int i = 0; i < lst.Count; i++)
            {
                if (!lst[i].Equals(lst1[i]))
                {
                    result = false;
                    break;
                }
            }
        }
        else
        {
            result = false;
        }
        if (result)
        {
            Response.Write("List are same");
        }
        else
        {
            Response.Write("List are not same");
        }
