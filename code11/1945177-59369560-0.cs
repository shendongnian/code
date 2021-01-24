c#
        private async void SetupAndStartMediaCapture()
        {
            string deviceId = string.Empty;
            _mediaCapture = new MediaCapture();
            DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            foreach (var device in devices)
            {
                if(MediaCapture.IsVideoProfileSupported(device.Id))
                {
                    deviceId = device.Id; 
                    break; // The video device for which supported video profile support is queried.
                }
            }
            MediaCaptureInitializationSettings mediaCapSettings = new MediaCaptureInitializationSettings
            {
                VideoDeviceId = deviceId
            };
            IReadOnlyList<MediaCaptureVideoProfile> profiles = MediaCapture.FindAllVideoProfiles(deviceId); 
 
            var profileMatch = (
                from profile in profiles
                from desc in profile.SupportedRecordMediaDescription
                where desc.Width == 896 && desc.Height == 504 && desc.FrameRate == 24     // HL1
                select new { profile, desc }
).FirstOrDefault();// Select the Profile with the required resolution from all available profiles.
            if (profileMatch != null)
            {
                mediaCapSettings.VideoProfile = profileMatch.profile;
                mediaCapSettings.RecordMediaDescription = profileMatch.desc;
            }
            await _mediaCapture.InitializeAsync(mediaCapSettings); //Initializes the MediaCapture object.
        }
