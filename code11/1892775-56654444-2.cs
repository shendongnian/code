    public List<Result> ComputeDistances(List<Coordinate> coordinates) {
        List<Result> results = new List<Result>();
        foreach (var coordinate in coordinates) {
            double distance = Math.Sqrt(coordinate.X + coordinate.Y); // *
            results.Add(new Result(coordinate, distance));
        }
        return results;
    }
