    public static double GetCosineSimilarity(List<double> V1, List<double> V2)
    {
        double sim = 0.0d;
        int N = 0;
        N = ((V2.Count < V1.Count)?V2.Count : V1.Count);
        double dot = 0.0d;
        double mag1 = 0.0d;
        double mag2 = 0.0d;
        for (int n = 0; n < N; n++)
        {
            dot += V1[n] * V2[n];
            mag1 += Math.Pow(V1[n], 2);
            mag2 += Math.Pow(V2[n], 2);
        }
        return dot / (Math.Sqrt(mag1) * Math.Sqrt(mag2));
    }
