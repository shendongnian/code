    [assembly: Xamarin.Forms.Dependency(typeof(DocumentView))]
    namespace FMSXMobileApp.Droid
    {
        public class DocumentView : IDocumentView
        {
            void IDocumentView.DocumentView(byte[] bytes, string name, string title)
            {
                var context = Android.App.Application.Context;
                
                try
                {
                    var filePath = CommonLibrary.Helpers.FileHelper.WriteFileFromByteArray(bytes, Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).Path, "fmsxapp.pdf");
                    var mime = MimeTypeMap.GetFileExtensionFromUrl(filePath);
                    // if copying was successful, start Intent for opening this file
                    if (System.IO.File.Exists(filePath))
                    {                    
                        Android.Net.Uri pdfPath = FileProvider.GetUriForFile(context, "com.mydomain.fileprovider", new Java.IO.File(filePath));
                        context.GrantUriPermission(context.PackageName, pdfPath, ActivityFlags.GrantReadUriPermission);
                        Intent intent = new Intent();
                        intent.SetFlags(ActivityFlags.GrantReadUriPermission);                    
                        intent.SetAction(Android.Content.Intent.ActionView);
                        intent.SetDataAndType(pdfPath, $"application/{mime}");
                        context.StartActivity(intent);
                    }
                }
                catch (ActivityNotFoundException anfe)
                {
                    // android could not find a suitable app for this file
                    var alert = new AlertDialog.Builder(context);
                    alert.SetTitle("Error");
                    alert.SetMessage("No suitable app found to open this file");
                    alert.SetCancelable(false);
                    alert.SetPositiveButton("Okay", (object sender, DialogClickEventArgs e) => ((AlertDialog)sender).Hide());
                    alert.Show();
                }
                catch (Exception ex)
                {
                    // another exception
                    var alert = new AlertDialog.Builder(context);
                    alert.SetTitle("Error");
                    alert.SetMessage("Error when opening document");
                    alert.SetCancelable(false);
                    alert.SetPositiveButton("Okay", (object sender, DialogClickEventArgs e) => ((AlertDialog)sender).Hide());
                    alert.Show();
                }
            }
        }
    }
