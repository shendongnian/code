    try
                        {
                            string extension = MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                            string mimeType = MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                            Intent intent = new Intent(Intent.ActionView);
                            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                            Android.Net.Uri path = FileProvider.GetUriForFile(Application.Context, Android.App.Application.Context.PackageName + ".provider", file);
                            intent.SetDataAndType(path, mimeType);
                            intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                            Application.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
                        }
                        catch (Exception ex)
                        {
                            Toast.MakeText(Application.Context, "problem", ToastLength.Long).Show();
                        }
