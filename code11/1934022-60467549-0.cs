    [SerializeField] ARRaycast​Manager raycastManager;
        void Update()
            {
                 if (Input.touchCount == 0)
                    return;
               Touch touch = Input.GetTouch(0);
          
               if (raycastManager.Raycast(touch.position,s_Hits,TrackableType.PlaneWithinPolygon))
                {
                    // Raycast hits are sorted by distance, so the first one
                    // will be the closest hit.
                    var hitPose = s_Hits[0].pose;
                    if (spawnedObject == null)
                    {
                        spawnedObject = Instantiate(cube, hitPose.position, hitPose.rotation);
                    }
                    else
                    {
                        spawnedObject.transform.position = hitPose.position;
                    }
                }
            }
