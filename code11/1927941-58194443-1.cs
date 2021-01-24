     if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == Permission.Granted && ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) == Permission.Granted)
          {
            Intent intent = new Intent(Intent.ActionView);
            intent.AddFlags(ActivityFlags.GrantReadUriPermission);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.SetDataAndType(FileProvider.GetUriForFile(this, "aaaa", new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads) + "/gcam14.apk")), "application/vnd.android.package-archive");
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.O)
                {
                    bool hasInstallPermission = PackageManager.CanRequestPackageInstalls();
                    if (!hasInstallPermission)
                    {
                        //Request permission to install unknown application source
                        ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.RequestInstallPackages }, 1);
                    }
                }
               StartActivity(intent);
              
          }
       else
          {
             ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.ReadExternalStorage }, 1);
          }
      
