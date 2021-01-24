public ActionResult Upload()
            {
                return View();
            }
            [HttpPost]
            public async Task<ActionResult> Upload(HttpPostedFileBase file)
            {
                string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string filepath = @"C:\Users\35385\source\repos\BookingSystem\BookingSystem\Surveys\" + filename;
                file.SaveAs(Path.Combine(Server.MapPath("/Surveys"), filename));
                await AzureVisionAPI.ExtractToTextFile(filepath);
                return View();
            }
AzureVisionAPI:
namespace BookingSystem.Helpers
{
    static class AzureVisionAPI
    {
        static string subscriptionKey = ("SUBSCRIPTON_KEY");
        static string endpoint = ("END_POINT");
        public static ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
                new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
                { Endpoint = endpoint };
            return client;
        }
        public static async Task ExtractToTextFile(string filename)
        {
            ComputerVisionClient client = Authenticate(endpoint, subscriptionKey);
            await ExtractTextLocal(client, filename);
        }
        public static async Task ExtractTextLocal(ComputerVisionClient client, string localImage)
        {
            // Helps calucalte starting index to retrieve operation ID
            const int numberOfCharsInOperationId = 36;
            using (Stream imageStream = File.OpenRead(localImage))
            {
                // Read the text from the local image
                BatchReadFileInStreamHeaders localFileTextHeaders = await client.BatchReadFileInStreamAsync(imageStream);
                // Get the operation location (operation ID)
                string operationLocation = localFileTextHeaders.OperationLocation;
                // Retrieve the URI where the recognized text will be stored from the Operation-Location header.
                string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);
                // Extract text, wait for it to complete.
                int i = 0;
                int maxRetries = 10;
                ReadOperationResult results;
                do
                {
                    results = await client.GetReadOperationResultAsync(operationId);
                    await Task.Delay(1000);
                    if (maxRetries == 9)
                    {
                        throw new Exception("Azure API timed out");
                    }
                }
                while ((results.Status == TextOperationStatusCodes.Running ||
                        results.Status == TextOperationStatusCodes.NotStarted) && i++ < maxRetries);
                // Display the found text.
                var textRecognitionLocalFileResults = results.RecognitionResults;
                foreach (TextRecognitionResult recResult in textRecognitionLocalFileResults)
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\35385\source\repos\BookingSystem\BookingSystem\surveytest.txt"))
                    {
                        foreach (Line line in recResult.Lines)
                        {
                            sw.WriteLine(line.Text);
                        }
                    }
                }
            }
        }
    }
}
