    public class PointsToViewResolver : IValueResolver<Problem, ProblemViewModel, string[][]>
    {
        public string[][] Resolve(
            Problem source,
            ProblemViewModel destination,
            string[][] destMember, 
            ResolutionContext context)
        {
            if (source.Points == null)
            {
                return new string[0][];
            }
            var rows = source.Points.Split(new string[] { Constants.PointsRowSeparator },
                StringSplitOptions.None);
            string[][] result = new string[rows.Length][];
            for (int row = 0; row < rows.Length; row++)
            {
                result[row] =
                    rows[row].Split(new string[] { Constants.PointsColSeparator },
                    StringSplitOptions.None);
            }
            return result;
        }
    }
