    List<Image> _captures = new List<Image>();
     new Thread(() =>
        {
            while (StillCapturing)
            {
                if (Camera.CheckForAndDownloadImage(CameraInstance))
                {
                    lock(_locker){_captures.Add(DisplayImage);
                }
            }
        }).Start();
