        [OperationContract]
        public Stream GetSomeData()
        {
        	var stream = new MemoryStream();
        	using(var file = File.OpenRead("path"))
	        {
                // write something to the stream:
                file.CopyTo(stream);		 
                // here, the MemoryStream is positioned at its end
	        }
            // This is the crucial part:
            stream.Position = 0L;
            return stream;
        }
