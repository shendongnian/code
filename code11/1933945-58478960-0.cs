        static void Main(string[] args)
        {
            string persionPicPath = @"<image path>";
            string endpoint = @"https://<your face service name>.cognitiveservices.azure.com/";
            string subscriptionKey = "<your subscription key>";
            IFaceClient faceClient = new FaceClient(
            new ApiKeyServiceClientCredentials(subscriptionKey),
            new System.Net.Http.DelegatingHandler[] { });
            faceClient.Endpoint = endpoint;
            using (Stream s = File.OpenRead(persionPicPath))
            {
                var facesResults = faceClient.Face.DetectWithStreamAsync(s, true, false, null).GetAwaiter().GetResult();
                foreach (var faces in facesResults)
                {
                    Console.WriteLine(faces.FaceId);
                }
                Console.ReadKey();
            }
        }
