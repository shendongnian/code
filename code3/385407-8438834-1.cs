    public IList<ResourceAndService> ReturnListOfServicesAndResources()
    {
        var dt = (from res in entities.Resource 
                    from service in res.Service 
                    select
                    new ResourceAndService()
                    {
                        Resource = res.ResourceID,
                        Service= ser.ServiceID,
                        (...)
                    }).ToList();
        return dt;
    }
