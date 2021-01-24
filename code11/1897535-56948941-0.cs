    if (Android.Content.Intent.ActionSend.Equals(action) && (type?.Equals("application/pdf") ?? false))
                    {
                        // This is just an example of the data stored in the extras 
                        var uriFromExtras = Intent.GetParcelableExtra(Intent.ExtraStream) as Android.Net.Uri;
                        var subject = Intent.GetStringExtra(Intent.ExtraSubject);
        
                        // Get the info from ClipData 
                        var pdf = Intent.ClipData.GetItemAt(0);
                                
                        // Open a stream from the URI 
                        var pdfStream = ContentResolver.OpenInputStream(pdf.Uri);
        
                        // Save it over 
                        var memOfPdf = new System.IO.MemoryStream();
                        pdfStream.CopyTo(memOfPdf);
                        var docsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                        var filePath = System.IO.Path.Combine(docsPath, "temp.pdf");
        
                        System.IO.File.WriteAllBytes(filePath, memOfPdf.ToArray());
        
                        Navigate(filePath);
        
                    }
