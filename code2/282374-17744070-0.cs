        static void Main(string[] args)
        {
            const string apiKey = "6ea5e2e61844608937376d514-us2";   // Replace it before
            const string listId = "y657cb2495";                      // Replace it before
            var options = new List.SubscribeOptions();
            options.DoubleOptIn = true;
            options.EmailType = List.EmailType.Html;
            options.SendWelcome = false;
            var mergeText = new List.Merges("email@provider.com", List.EmailType.Text)
                        {
                            {"FNAME", "John"},
                            {"LNAME", "Smith"}
                        };
            var merges = new List<List.Merges> { mergeText };
            var mcApi = new MCApi(apiKey, false);
            var batchSubscribe = mcApi.ListBatchSubscribe(listId, merges, options);
            if (batchSubscribe.Errors.Count > 0)
                Console.WriteLine("Error:{0}", batchSubscribe.Errors[0].Message);
            else
                Console.WriteLine("Success");
            Console.ReadKey();
        }
