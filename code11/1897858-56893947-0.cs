    services.AddMvc(options =>
    {                    
        options.ModelBinderProviders.Insert(0, new UserTokenBinderProvider());
        options.ModelMetadataDetailsProviders.Add(
            new BindingSourceMetadataProvider(typeof(UserTokenBinder), BindingSource.Special));
    });
    
