        [ServiceContract]
        interface IService
        {
            [OperationContract]
            Task UploadStream(Stream stream);
        }
        public class MyService : IService
        {
            public async Task UploadStream(Stream stream)
            {
                using (stream)
                {
                    using (var file = File.Create(Path.Combine(Guid.NewGuid().ToString() + ".png")))
                    {
                        await stream.CopyToAsync(file);
                    }
                }
            }
    }
