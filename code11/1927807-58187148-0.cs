void StartExtendedTracking()
{
  PositionalDeviceTracker extendedTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();        
  if( extendedTracker != null && extendedTracker.IsActive )         
  {
        extendedTracker.Start();         
  }
}
void StopExtendedTracking()
{
  PositionalDeviceTracker extendedTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();        
  if( extendedTracker != null && extendedTracker.IsActive )         
  {
        extendedTracker.Start();         
  }
}
//If you want to disable/enable tracking completely then call the below functions
void StopTracking()
{
 TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
}
void StartTracking()
{
 TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
}
