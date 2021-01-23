        void handlerForImageBuffer()
        {
            Bitmap mp = (Bitmap)Bitmap.FromFile(@"path.bmp");
            for ( ; ; )
            {
                Console.WriteLine("Count: " + queueForImages.Count);
                if (queueForImages.Count == 10)
                {
                    queueFlag = true;                  
                    Thread imageThread = new Thread(new ThreadStart(processImages));
                    imageThread.Start();//Here comes the exception
                    Console.WriteLine("Q HAS 10 Elements");
                }
                queueForImages.Enqueue(Process(mp));//Same image is added for infinite times, just for the sake of testing.
            }
        }
