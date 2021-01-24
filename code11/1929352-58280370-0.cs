     Console.WriteLine("Using model to make single prediction -- Comparing actual Spam with predicted Spam from sample data...\n\n");
                Console.WriteLine($"Message: {sampleData.Message}");
                Console.WriteLine($"\n\nActual Spam: {sampleData.Spam} \nPredicted Spam: {predictionResult.Prediction}\n\n");
                Console.WriteLine("=============== End of process, hit any key to finish ===============");
                Console.ReadKey();
