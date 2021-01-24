    IList<portable.ActionReturnResult> GetPage(IList<portable.ActionReturnResult> list, 
        int page, int pageSize)
    {
        return list.Skip((page-1) * pageSize).Take(pageSize).ToList();
                        //subtract 1 here
    }
