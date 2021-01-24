        var options = new CouchbaseClientDefinition
          {
               Servers = new List<Uri>
               {
                    new Uri("http://couchbase.com/")
                }
           };
        var couchbaseCacheBucketProvider= new CouchbaseCacheBucketProvider
    	{
    		...
    	};
    
     Bind<ICouchbaseClientDefinition().To<CouchbaseCache >()
                .WithConstructorArgument(couchbaseCacheBucketProvider, options);
