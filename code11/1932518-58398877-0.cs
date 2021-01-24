            var populationSize = 60;
            var weights = 60;
            List<double>[] populationWeights = new List<double>[populationSize];
            List<double> results = new List<double>();
            for (int i = 0; i < populationSize; i++)
            {
                populationWeights[i] = new List<double>();
                for(int j = 0; j < weights; j++)
                {
                    populationWeights[i].Add(((_rand.NextDouble() * 2) - 1));
                }
            }
            //See how these weights perform on the task when applied to the network
            for(int i = 0; i < populationWeights.Length; i++)
            {
                results.Add(GetResults(populationWeights[i]));
                Console.WriteLine(results[i]);
            }
            Console.ReadLine();
