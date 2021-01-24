    foreach(var site in sites)
    {
        //if only one binding
        var port = site.Bindings[0].EndPoint.Port.ToString();
        //if more than one binding
        foreach(var binding in site.Bindings)
        {
            var port = binding.EndPoint.Port.ToString();
        }
    }
