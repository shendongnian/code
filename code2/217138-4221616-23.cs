    public void UpdateModel(Post post)
    {
       var stub = new Review {PostId = post.PostId};
       CurrentEntitySet.Attach(stub);
       Context.ApplyCurrentValues(GetEntityName<Post>(), post);
    }
