    public void UpdateModel<T>(T post) where T : Post, new()
    {
       var stub = new T { PostId = post.PostId };
       CurrentEntitySet.Attach(stub);
       Context.ApplyCurrentValues(GetEntityName<T>, post);
    }
