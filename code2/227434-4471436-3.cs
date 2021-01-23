    abstract class BaseAlgorithm {
      DataRepository repository;
    }
    
    class SampleNoCacheAlgorithm extends BaseAlgorithm {
      void processData(Data in, Data out) {
        // do something with in to compute out
      }
    }
    
    class SampleCacheProducerAlgorithm extends BaseAlgorithm {
      static Key KEY = "SampleCacheProducerAlgorithm.myKey";
      
      void processData(Data in, Data out) {
        // do something with in to compute out
        // then call repository.cacheData(KEY, out);
      }
    }
    
    class SampleCacheConsumerAlgorithm extends BaseAlgorithm {
      void processData(Data in, Data out) {
        // Data tmp = repository.retrieveData(SampleCacheProducerAlgorithm.KEY, in);
        // do something with in and tmp to compute out
      }
    }
    
