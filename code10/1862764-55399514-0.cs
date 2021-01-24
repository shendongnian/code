    public void ReceiveDetections(Detections detections)
    {
        SparseArray qrcodes = detections.DetectedItems;
        if (qrcodes.Size() != 0)
        {
            txtResult.Post(() => {
                //Vibrator vibrator = (Vibrator)GetSystemService(Context.VibratorService);
                //vibrator.Vibrate(1000);
                txtResult.Text = ((Barcode)qrcodes.ValueAt(0)).RawValue;
            });
            cameraSource.Stop();
        }
    }
