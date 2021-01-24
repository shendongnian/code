    void Update()
    {
    _UpdateApplicationLifecycle();
    // Hide snackbar when currently tracking at least one plane.
    Session.GetTrackables<DetectedPlane>(m_AllPlanes);
    bool showSearchingUI = true;
    for (int i = 0; i < m_AllPlanes.Count; i++)
    {
        if (m_AllPlanes[i].TrackingState == TrackingState.Tracking)
        {
            showSearchingUI = false;
            break;
        }
    }
    SearchingForPlaneUI.SetActive(showSearchingUI);
  
    Touch touch;
    if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase !=     TouchPhase.Began)
    {
        return;
    }
    // Should not handle input if the player is pointing on UI.
    if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
    {
        return;
    }
    if (mIsSecondTargetVisible)
    {
        return;
    }
    TrackableHit hit;
    TrackableHitFlags raycastFilter =         TrackableHitFlags.PlaneWithinPolygon |
    TrackableHitFlags.FeaturePointWithSurfaceNormal;
    if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
    if ((hit.Trackable is DetectedPlane) && Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
      hit.Pose.rotation * Vector3.up) < 0)
     {
     Debug.Log("Hit at back of the current DetectedPlane");
     }
     else
     {
    anchor = hit.Trackable.CreateAnchor(hit.Pose);
    if (mIsFirsttargetVisible == false){                     
    target1 = Instantiate(cubes, hit.Pose.position, hit.Pose.rotation);
    target1.transform.localScale = new Vector3(0.02f, 0.001f, 0.02f);
    target1.transform.parent = anchor.transform;
    mIsFirsttargetVisible = true;                    
    }
    else if (mIsSecondTargetVisible == false){
    target2 = Instantiate(cubes, hit.Pose.position, hit.Pose.rotation);
    target2.transform.localScale = new Vector3(0.02f, 0.001f, 0.02f);
    target2.transform.parent = anchor.transform;
    mIsSecondTargetVisible = true;
              }
        }
    }
    if (mIsSecondTargetVisible)
    {
      DrawPoints(target1, target2, Color.red, 0.2f);
    }
    }
