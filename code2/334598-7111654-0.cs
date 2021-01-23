    private static void uploadImage()
            {
                try
                {
    
                    foreach (var img in lImageSet)
                    {
                        Console.WriteLine("Image Name: {0}", img.getName());
                    }
    
                    foreach (var img in lImageSet)
                    {
                        //Counter to track the number of images that have been uploaded
                        i++;
    
                        
                        //For every 10 images that are uploaded, to reduce congestion, log out of SharePoint and log back in.
                        if (i % 10 == 0)
                        {
                            clientContext.Dispose();
                            sharepointLogin();
                        }
    
                        ....
