    var httpcontext = System.Web.HttpContext.Current;
    var opcontext = System.ServiceModel.OperationContext.Current;
    Parallel.ForEach(types, (p) =>
    {
        System.Web.HttpContext.Current = httpcontext;
        System.ServiceModel.OperationContext.Current = opcontext;
        
        // DO YOUR PARALLEL PROCESSING HERE
    });
