        public class ImageRetriever
        { 
            public void ProcessImage()
            {
                //if you would like to get rid of the async
                //reminder that calling .Result is blocking for the current thread.
                //this means the thread will stop working untill the result is returned
                //could be an issue if this is called on UI thead
                var imageTask = GetImage();
                Image image = imageTask.Result;
            }
    
            public async Task ProcessImageAsync()
            {
                //if you want to keep the async-nonblocking
                Image image = await GetImage();
            } 
            private Task<Image> GetImage()
            {
                //this is how your create your task
                Task<Image> imageTask;
                imageTask = Task.Run(() =>
                {
                    return new Image();
                });
                // or
                imageTask = Task.Factory.StartNew(() =>
                {
                    return new Image();
                });
                return imageTask;
            }
        }
    
        public class Image
        {
    
        }
