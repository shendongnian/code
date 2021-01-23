    public static double GetCosineSimilarity(Point V1, Point V2) {
     return (V1.X*V2.X + V1.Y*V2.Y) 
             / ( Math.Sqrt( Math.Pow(V1.X,2)+Math.Pow(V1.Y,2))
                 Math.Sqrt( Math.Pow(V2.X,2)+Math.Pow(V2.Y,2))
               );
    }
