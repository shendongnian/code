    private void Awake()
    {
        var cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height);
        // Create a PhotoCapture object
        PhotoCapture.CreateAsync(false, captureObject =>
        {
            photoCaptureObject = captureObject;
            cameraParameters.hologramOpacity = 0.0f;
            cameraParameters.cameraResolutionWidth = cameraResolution.width;
            cameraParameters.cameraResolutionHeight = cameraResolution.height;
            cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;
        });
    }
    private void Update()
    {
        // if not initialized yet don't take input
        if (photoCaptureObject == null) return;
        if (Input.GetKeyDown("k"))
        {
            Debug.Log("k was pressed");
            VuforiaBehaviour.Instance.gameObject.SetActive(false);
            // Activate the camera
            photoCaptureObject.StartPhotoModeAsync(cameraParameters, result =>
            {
               if (result.success)
               {
                   // Take a picture
                   photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
               }
               else
               {
                   Debug.LogError("Couldn't start photo mode!", this);
               }
           });
        }
    }
    private static string FileName(int width, int height)
    {
        return $"screen_{width}x{height}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
    }
    private void OnCapturedPhotoToMemory(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    {
        // Copy the raw image data into the target texture
        photoCaptureFrame.UploadImageDataToTexture(targetTexture);
        Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        targetTexture.ReadPixels(new Rect(0, 0, cameraResolution.width, cameraResolution.height), 0, 0);
        targetTexture.Apply();
        byte[] bytes = targetTexture.EncodeToPNG();
        string filename = FileName(Convert.ToInt32(targetTexture.width), Convert.ToInt32(targetTexture.height));
        //save to folder under assets
        File.WriteAllBytes(Application.streamingAssetsPath + "/Snapshots/" + filename, bytes);
        Debug.Log("The picture was uploaded");
        // Deactivate the camera
        photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
    }
    private void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
    {
        // Shutdown the photo capture resource
        photoCaptureObject.Dispose();
        photoCaptureObject = null;
        VuforiaBehaviour.Instance.gameObject.SetActive(true);
    }
