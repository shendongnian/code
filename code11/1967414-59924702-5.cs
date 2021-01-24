     var options = new ZXing.Mobile.MobileBarcodeScanningOptions()
     {
       PossibleFormats = new List<ZXing.BarcodeFormat>() { ZXing.BarcodeFormat.QR_CODE },
       CameraResolutionSelector = DependencyService.Get<IZXingHelper>().SelectLowestResolutionMatchingDisplayAspectRatio
     };
