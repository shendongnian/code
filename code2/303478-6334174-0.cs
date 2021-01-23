    var factory = new SparkViewFactory(settings)
                   {
                       ViewFolder = new FileSystemViewFolder(viewsLocation)
                   };
    // And generate all of the known view/master templates into the target assembly
    var batch = new SparkBatchDescriptor(targetPath);
            
    factory.Precompile(batch);
