    public enum PhotoProcessingMethod { A, B }
    public interface IProcessedPhoto
    {
         void Alter();
    }
    public AProcessedPhoto : IProcessedPhoto
    {
         ...
         public void Alter()
         {
            ... alter an A...
         }
    }
 
    public BProcessedPhoto : IProcessedPhoto
    {
         ...
         public void Alter()
         {
          ... alter a B...
        }
    }
    public interface IPhotoProcessor
    {
         IProcessedPhoto Process(byte[] bytes, PhotoProcessingMethod method);
    }
    public class PhotoProcessor : IPhotoProcessor
    {
         public IProcessedPhoto Process(byte[] bytes, PhotoProcessingMethod method)
         {
              IProcessedPhoto photo;
              switch (method)
              {
                  case PhotoProcessingMethod.A:
                       photo = new AProcessedPhoto(bytes);
                       break;
                  case PhotoProcessingMethod.B:
                       photo = new BProcessedPhoto(bytes);
                       break;
              }
              ...
              return photo;
         }
    }
