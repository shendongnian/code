    bool processed = false;
    foreach(var checkFactory in availableFactories)
    {
      if (checkFactory(VIF))
      {
         var processingFactory = processingFactories.Resolve(ItemType);
         processingFactory.Process(VIF);
         processed = true;
      }
    }
