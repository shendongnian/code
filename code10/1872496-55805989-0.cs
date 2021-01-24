    try
    {
        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
        if (status != PermissionStatus.Granted)
        {
            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
            {
                //await DisplayAlert("Need location", "Gunna need that location", "OK");
                Console.WriteLine("OK");
            }
    
            var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
            //Best practice to always check that the key exists
            if (results.ContainsKey(Permission.Storage))
                status = results[Permission.Storage];
        }
    
        if (status == PermissionStatus.Granted)
        {
            string root = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            Java.IO.File myDir = new Java.IO.File(root + "/Screenshots");
            myDir.Mkdirs();
    
            string fname = "test_picture.jpg";
    
            Java.IO.File file = new Java.IO.File(myDir, fname);
            Console.WriteLine("------root-------" + file.Path);
    
            FileStream outStream = new FileStream(file.Path, FileMode.OpenOrCreate);
            ....
        }
        else if (status != PermissionStatus.Unknown)
        {
            Console.WriteLine("OK");
            //await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("" + ex);
    }
