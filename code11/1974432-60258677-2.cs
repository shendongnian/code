     var externalPath = global::Android.OS.Environment.ExternalStorageDirectory.Path + "/testfolder";
            Java.IO.File file = new Java.IO.File(externalPath, "test.pdf");
            if(file.Exists())
            {
                var context = Android.App.Application.Context;
                try
                {
                   
                    Android.Net.Uri pdfPath = FileProvider.GetUriForFile(context, context.ApplicationContext.PackageName + ".provider", file);
                    context.GrantUriPermission(context.PackageName, pdfPath, ActivityFlags.GrantReadUriPermission);
                    Intent intent = new Intent();
                    intent.SetFlags(ActivityFlags.GrantReadUriPermission);
                    intent.SetAction(Android.Content.Intent.ActionView);
                    intent.SetFlags(ActivityFlags.NoHistory);
                    intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);
                    intent.SetDataAndType(pdfPath, "application/pdf");
                    context.StartActivity(intent);
                }
                catch (Exception ex)
                {
                    Toast.MakeText(Application.Context, "problem", ToastLength.Long).Show();
                }
            }
