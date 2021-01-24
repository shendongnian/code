    using (var ctx = new ABCDXContext())
    {
        var count = 0;
        foreach (var filter in filterList)
        {
            ctx.ut_katabcdx_file_filters.Add(filter);
            count++;
            if (count > 100)
            {
                ctx.SaveChanges();
                count = 0;
            }
        }
        ctx.SaveChanges();
        string param_xml = GetParamXml();
        Products = new ObservableCollection<ut_katabcdx_wytwor>(ctx.WytworFileUpdate(param_xml));
    }
