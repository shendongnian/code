    PHPhotoLibrary.RequestAuthorization((status) =>
    {
       switch (status)
       {
           case PHAuthorizationStatus.Authorized:
               {
                   Debug.WriteLine(“Authorized to access”);
                   break;
               }
           case PHAuthorizationStatus.Denied: case PHAuthorizationStatus.Restricted:
               {
                   Debug.WriteLine(“Not allowed”);
                   break;
               }
           default:
               {
                   Debug.WriteLine(“Not determined”);
                   break;
               }
       }
    });
