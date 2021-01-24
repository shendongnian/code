csharp
[Binding]
class StepSetup
{
    [BeforeTestRun]
    public static void InitializeReport()
    {
        Reporter.ReportInit();
    }
    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        var reporter = new Reporter();
        reporter.ReportFeature(featureContext);
    }
}
Then change the Reporter class to accept a FeatureContext argument in ReportFeature:
csharp
class Reporter
{
    public static ReportInit()
    {
        // does stuff
    }
    public void ReportFeature(FeatureContext featureContext)
    {
        featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
    }
}
If the Reporter.ReportFeature method does not use any instance fields, consider making this method a static method as well, and using a static constructor instead of the Reporter.ReportInit() method:
csharp
static class Reporter
{
    static Reporter()
    {
        // does stuff
    }
    public static void ReportFeature(FeatureContext featureContext)
    {
        featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
    }
}
Then your StepSetup class becomes even simpler with no need to call a static "init" method on the Reporter class:
csharp
[Binding]
class StepSetup
{
    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        Reporter.ReportFeature(featureContext);
    }
}
See [Static Constructors (C# Programming Guide)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors)
