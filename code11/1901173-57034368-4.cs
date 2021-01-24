    public static async Task UploadAsync(string url, int job_id, string filename, string filePath) {
      try {
          // Submit the form using HttpClient and 
          // create form data as Multipart (enctype="multipart/form-data")
          using (var fileStream = new StreamContent(System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read)))
          using (var formData = new MultipartFormDataContent()) {
              StringContent sJobId = new StringContent(job_id.ToString());
              StringContent sOthId = new StringContent(job_id.ToString());
              // Try as I might C# adds a CrLf to the end of the job_id tag - so have to strip it in ruby
              formData.Add(sOthId, "\"oth_id\"");
              formData.Add(sJobId,"\"job_id\"");
              fileStream.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
              formData.Add(fileStream, "\"dt_file\"", filename);
              HttpResponseMessage response = await HttpClient.PostAsync(url, formData);
    
              // If the upload failed there is not a lot we can do 
              return;
          }
      } catch (Exception ex) {
          // Not a lot we can do here - so just ignore it
          System.Diagnostics.Debug.WriteLine($"Upload failed {ex.Message}");
      }
    
    }
