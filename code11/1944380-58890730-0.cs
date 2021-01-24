    public Master Add(Master request)
    {
        request.CreatedDate = DateTime.Now;
        // master
        Context.Entry(request).State = EntityState.Added;
        Context.SaveChanges();
        return request;
    }  
