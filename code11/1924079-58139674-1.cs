                    Intent viewIntent = new Intent(Intent.ActionView);
                    //viewIntent.SetAction();
                    Java.IO.File exportFile = new Java.IO.File(localPhotoPath);
                    exportFile.SetReadable(true);
                    var photoURI = FileProvider.GetUriForFile(Application.Context, Application.Context.ApplicationContext.PackageName + ".fileprovider", exportFile);
                    viewIntent.SetDataAndType(photoURI, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                    viewIntent.AddFlags(ActivityFlags.NewTask);
                    viewIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
                    viewIntent.AddFlags(ActivityFlags.GrantWriteUriPermission);
                    var resolved = PackageManager.QueryIntentActivities(viewIntent, 0);
                    if (resolved != null && resolved.Count > 0)
                    {
                        foreach (var t in resolved)
                        {
                            Application.Context.GrantUriPermission(t.ActivityInfo.PackageName, photoURI, ActivityFlags.GrantReadUriPermission);
                        }
                        StartActivity(viewIntent);
                    }
                    else
                    {
                        // notify the user they can't open it.
                    }
