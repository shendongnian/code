csharp
public static void Main(string[] args)
{
    var points = new List<Point>
    {
        new Point
        {
            BuildingName = "ABC Office",
            TaskName = "Temperature",
            PointName = "14",
            DataName = "Temperature: Degrees F",
            Results = new List<Result> {
                new Result { Local = new DateTime(2019, 1,1), Value = 2},
                new Result { Local = new DateTime(2019, 1, 2), Value = 23}
            }
        },
        new Point
        {
            BuildingName = "Sarah's Office",
            TaskName = "Fan",
            PointName = "33",
            DataName = "0=Stop;1=Run",
            Results = new List<Result> {
                new Result { Local = new DateTime(2019, 1,1), Value = 2},
                new Result { Local = new DateTime(2019, 1, 2), Value = 23},
                new Result { Local = new DateTime(2019, 1, 3), Value = 45},
                new Result { Local = new DateTime(2019, 1, 4), Value = 34},
                new Result { Local = new DateTime(2019, 1, 5), Value = 36}
            }
        },
        new Point
        {
            BuildingName = "Brian's Office",
            TaskName = "Fan",
            PointName = "35",
            DataName = "Humidity",
            Results = new List<Result> {
                new Result { Local = new DateTime(2019, 1,1), Value = 2},
                new Result { Local = new DateTime(2019, 1, 2), Value = 23},
                new Result { Local = new DateTime(2019, 1, 3), Value = 45},
                new Result { Local = new DateTime(2019, 1, 4), Value = 34},
                new Result { Local = new DateTime(2019, 1, 5), Value = 36},
                new Result { Local = new DateTime(2019, 1, 6), Value = 56},
                new Result { Local = new DateTime(2019, 1, 7), Value = 92}
            }
        },
    };
    using (var writer = new StreamWriter(filePath))
    using (var csv = new CsvWriter(writer))
    {
        // Print buildings
        foreach (var point in points)
        {
            csv.WriteField(point.BuildingName);
            csv.WriteField("");
        }
        csv.NextRecord();
        // Print Tasks
        foreach (var point in points)
        {
            csv.WriteField(point.TaskName);
            csv.WriteField("");
        }
        csv.NextRecord();
        // Print Points
        foreach (var point in points)
        {
            csv.WriteField(point.PointName);
            csv.WriteField("");
        }
        csv.NextRecord();
        // Print DataNames
        foreach (var point in points)
        {
            csv.WriteField(point.DataName);
            csv.WriteField("");
        }
        csv.NextRecord();
        // Print value titles
        foreach (var point in points)
        {
            csv.WriteField("Local");
            csv.WriteField("Value");
        }
        csv.NextRecord();
        var endReached = false;
        var pointIndex = 0;
        // Print values
        while (!endReached)
        {
            endReached = true;
            foreach (var point in points)
            {
                if (point.Results.Count > pointIndex)
                {
                    csv.WriteField(point.Results[pointIndex].Local);
                    csv.WriteField(point.Results[pointIndex].Value);
                    if (point.Results.Count > pointIndex + 1)
                    {
                        endReached = false;
                    }
                }
                else
                {
                    csv.WriteField("");
                    csv.WriteField("");
                }
            }
            csv.NextRecord();
            pointIndex += 1;
        }
    }
}
public class Point
{
    public string BuildingName { get; set; }
    public string TaskName { get; set; }
    public string PointName { get; set; }
    public string DataName { get; set; }
    public List<Result> Results { get; set; }
}
public class Result
{
    public DateTime Local { get; set; }
    public int Value { get; set; }
}
