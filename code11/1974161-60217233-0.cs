    bool calibrated = false;
    bool startedCalibration = false;
    private void Update()
    {
        if (Input.GetKeyDown(_startKey) && !startedCalibration)
        {
            startedCalibration = true;
            StartCalibration(
                resultCallback: (calibrated) =>
                {
                    startedCalibration = false;
                    print("Calibration was " + (calibrated ? "successful" : "unsuccessful");
                    // Assign the local scope variable to the class property:
                    this.calibrated = calibrated;
                }
            );
        }
        
        if (calibrated)
        {
            calibrated = false;
            SceneManager.LoadScene("MainScene");
        }
    }
