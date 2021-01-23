var client = AWSClientFactory.CreateAmazonCloudWatchClient(
    &lt;AWSAccessKey&gt;,
    &lt;AWSSecretKey&gt;);
var dimension = new Dimension
{
    Name = "InstanceId",
    Value = &lt;InstanceId&gt;,
};
var request = new GetMetricStatisticsRequest();
request.Dimensions.Add(dimension);
var currentTime = DateTime.UtcNow;
var startTime = currentTime.AddMinutes(-5);
request.StartTime = startTime.ToString(
    AWSSDKUtils.ISO8601DateFormat,
    CultureInfo.InvariantCulture.DateTimeFormat);
request.EndTime = currentTime.ToString(
    AWSSDKUtils.ISO8601DateFormat,
    CultureInfo.InvariantCulture.DateTimeFormat);
request.Namespace = "AWS/EC2";
request.Statistics.Add("Maximum");
request.Statistics.Add("Average");
request.MeasureName = "CPUUtilization";
request.Period = 300;
var response = client.GetMetricStatistics(request);
if (response.IsSetGetMetricStatisticsResult() &amp;&amp;
    response.GetMetricStatisticsResult.Datapoints.Count &gt; 0)
{
    var dataPoint = response.GetMetricStatisticsResult.Datapoints[0];
    Console.WriteLine(
        "Instance: {0} CPU Average load: {1} CPU Max load: {2}",
        instanceID,
        dataPoint.Average,
        dataPoint.Maximum);
}
