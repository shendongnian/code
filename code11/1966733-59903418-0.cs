    public class PointsToDbResolver : IValueResolver<ProblemViewModel, Problem, string>
    {
        public string Resolve(
            ProblemViewModel source,
            Problem destination,
            string destMember, 
            ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < source.Points.GetLength(0); row++)
            {
                for (int col = 0; col < source.Points[row].Length; col++)
                {
                    result.Append(source.Points[row][col]).Append(Constants.PointsColSeparator);
                }
                result.Replace(
                    Constants.PointsColSeparator,
                    Constants.PointsRowSeparator,
                    result.Length - 1, 1);
            }
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
