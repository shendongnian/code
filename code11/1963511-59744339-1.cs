          public string RecognizeImage(Bitmap bitmap)
        {
            var outputNames = new[] { OutputName };
            var floatValues = GetBitmapPixels(bitmap);
            var outputs = new float[labels.Count];
            inferenceInterface.Feed(InputName, floatValues, 1, _inputSize, _inputSize, 3);
            inferenceInterface.Run(outputNames);
            inferenceInterface.Fetch(OutputName, outputs);
            var results = new List<Tuple<float, string>>();
            for (var i = 0; i < outputs.Length; ++i)
                results.Add(Tuple.Create(outputs[i], labels[i]));
            return results.OrderByDescending(t => t.Item1).First().Item2;
        }
