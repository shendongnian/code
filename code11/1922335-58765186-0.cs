    public class GifService : IGifService
    {
        public string CreateGif(string frame1Path, string frame2Path, string frame3Path, string frame4Path,string webId,string path="")
        {
            List<UIImage> listOfFrame = new List<UIImage>();
            UIImage image1 = new UIImage(frame1Path);
            listOfFrame.Add(image1);
            UIImage image2 = new UIImage(frame2Path);
            listOfFrame.Add(image2);
            UIImage image3 = new UIImage(frame3Path);
            listOfFrame.Add(image3);
            UIImage image4 = new UIImage(frame4Path);
            listOfFrame.Add(image4);
            NSMutableDictionary fileProperties = new NSMutableDictionary
            {
                { CGImageProperties.GIFLoopCount, new NSNumber(1) }
            };
            NSUrl documentsDirectoryUrl = NSFileManager.DefaultManager.GetUrl(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User,null, true,out _);
            NSUrl fileUrl = documentsDirectoryUrl.Append(webId + ".gif",false);
            
            var destination = CGImageDestination.Create(fileUrl, MobileCoreServices.UTType.GIF, 4);
            destination.SetProperties(fileProperties);
            foreach (var frame in listOfFrame)
            {
                //difference is here, i create a var option and i set the 
                //GifDictionary
                var options = new CGImageDestinationOptions();
                options.GifDictionary = new NSMutableDictionary();
                options.GifDictionary[CGImageProperties.GIFDelayTime] = new NSNumber(1f);
                var cgImage = frame.CGImage;
                if(cgImage!= null)
                {
                    destination.AddImage(cgImage, options);
                }
            }
            if (!destination.Close())
            {
                Console.WriteLine("Failed to finalize the image destination");
            }
            return fileUrl.Path;
        }
    }
