     if (CheckSelfPermission(Manifest.Permission.WriteExternalStorage) == Permission.Granted)
         {
           var path =  Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
           string strpath = System.IO.Path.Combine(path.ToString(), "test.jpg");
           Java.IO.File file = new Java.IO.File(strpath);
           ...
           var filePackage = PackageName + ".fileprovider";
           var uri = FileProvider.GetUriForFile(this, filePackage, file);
           Intent intent = new Intent(this, typeof(PhotoActivity));
           intent.AddFlags(ActivityFlags.GrantReadUriPermission);
           intent.SetDataAndType(uri, "application/vnd.android.package-archive");
           StartActivity(intent);
         }
      else
         {
           RequestPermissions(new string[] { Manifest.Permission.WriteExternalStorage }, 1);
         }
