    // In your source, you use yield
    public ClassImplementingIEnumerable: IEnumerable<int>
    {
     public IEnumerable<int> GetSource()
     {
           for (int i=0;i<1000;++i)
               yield return i;
     }
    }
    public class ParallelProcessingConsumer {
    public void SomeMethod(ClassImplementingIEnumerable sourceProvider)
    {
       
          Parallel.ForEach(sourceProvider.GetSource(), parallelOptions, (i, loopState) => 
          {  
             // Do work in parallel!
          });
    }
