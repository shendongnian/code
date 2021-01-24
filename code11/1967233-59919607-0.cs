cs
// First of get the IVsSolutionBuildManager via the SVsSolutionBuildManager with the GetService method
var service = GetService(typeof(SVsSolutionBuildManager)) as IVsSolutionBuildManager;
// Appending the Events
service.AdviseUpdateSolutionEvents(new Events(), out var cookie)
// The class which handles the Event callbacks
public class Events : IVsUpdateSolutionEvents
{
   // The implemented methods from the interface
}
