protected virtual void OnTrackingFound()
{
  ....
  ....
  StartCoroutine(TurnOffTracking());
}
IEnumerator TurnOffTracking()
{
  yield return new WaitForSeconds(2); //Keeping a delay of 2 seconds after the image has been tracked
  TrackerManager.Instance.GetTracker<ObjectTracker>().Stop(); //Tracking will be stopped and the objects that have been positioned after getting tracked will be in the same position in world space
}
Make sure you do the following changes in the project:
(a) Extended tracking (device position tracker) is enabled.
(b) Set world center mode of Vuforia Behaviour in AR camera to "DEVICE".
