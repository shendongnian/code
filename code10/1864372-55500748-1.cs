    using Google.Cloud.Vision.V1; 
    using Google.Api.Gax;
    using Google.Api.Gax.Grpc;
    var timeout = new TimeSpan(0, 0, 2);
    CallSettings callSettings = CallSettings.FromCallTiming(CallTiming.FromExpiration(Expiration.FromTimeout(timeout)));
    
    var image = Google.Cloud.Vision.V1.Image.FromFile(sFilename);
    var client = ImageAnnotatorClient.Create();
    var response = client.DetectText(image, null, 0, callSettings);
