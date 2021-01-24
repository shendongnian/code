                if (prediction.Prediction[2] < (1 - 0.95))
                {
                    prediction.Prediction[0] = 1;
                }
                Console.WriteLine($"{prediction.Prediction[0]}\t{prediction.Prediction[1]}\t{prediction.Prediction[2]:0.000}");
