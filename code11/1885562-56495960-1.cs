               var options1 = new CouchbaseClientDefinition
    			{
    				...
    			};
    
    			var options2 = new CouchbaseClientDefinition
    			{
    				...
    			};
                var couchbaseCacheBucketProvider1= new CouchbaseCacheBucketProvider
    			{
    				...
    			};
                var couchbaseCacheBucketProvider2= new CouchbaseCacheBucketProvider
    			{
    				...
    			};
    
    
    			Bind < ICouchbaseClientDefinition().To<CouchbaseCache>().WithConstructorArgument(couchbaseCacheBucketProvider, options1).Named("FirstBinding");
    			Bind < ICouchbaseClientDefinition().To<CouchbaseCache>().WithConstructorArgument(couchbaseCacheBucketProvider, options2).Named("SecondBinding");
