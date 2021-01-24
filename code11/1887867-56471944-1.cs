 public static HttpResponseMessage AttachmentsByFlurl(string ticket, string project_id,
            string originalPath, string thumbPath,
            string container_id, string container_type)
        {
            // Compose Attachment JSON string 
            FileInfo original = new FileInfo(originalPath);
            Dictionary<string, string> att = new Dictionary<string, string>();
            // date time format: "2015-08-05 15:28:17 -0500";
            string dateTimeFormat = "yyyy-MM-dd HH:mm:ss zzz";
            string curTime = DateTime.Now.ToString(dateTimeFormat);
            att["fcreate_date"] = original.CreationTime.ToString(dateTimeFormat);
            att["fmod_date"] = original.LastWriteTime.ToString(dateTimeFormat);
            att["created_at"] = curTime;
            att["updated_at"] = curTime;
            att["size"] = original.Length.ToString();
            att["content_type"] = MimeMapping.GetMimeMapping(original.Name);
            att["filename"] = original.Name;
            att["container_id"] = container_id;     // e.g., issue_id 
            att["container_type"] = container_type; // e.g., "Issue" 
            // Conver to JSON format
            string attachment = Newtonsoft.Json.JsonConvert.SerializeObject(att);
            var mpc = new MultipartContent();
            var ticketContent = new StringContent(ticket);
            ticketContent.Headers.Add("Content-Disposition", "form-data; name=\"ticket\"");
            mpc.Add(ticketContent);
            var projectIdContent = new StringContent(project_id);
            projectIdContent.Headers.Add("Content-Disposition", "form-data; name=\"project_id\"");
            mpc.Add(projectIdContent);
            var attachmentContent = new StringContent(attachment, Encoding.UTF8, "application/json");
            attachmentContent.Headers.Add("Content-Disposition", "form-data; name=\"attachment\"");
            mpc.Add(attachmentContent);
            var attachmentFileStream = File.OpenRead(originalPath);
            var attachmentContentStream = new StreamContent(attachmentFileStream);
            attachmentContentStream.Headers.Add("Content-Disposition", string.Format("form-data; name=\"original\"; filename=\"{0}\"", Path.GetFileName(originalPath)));
            mpc.Add(attachmentContentStream);
            if(!string.IsNullOrEmpty(thumbPath))
            {
                var thumbFileStream = File.OpenRead(thumbPath);
                var thumbContentStream = new StreamContent(thumbFileStream);
                thumbContentStream.Headers.Add("Content-Disposition", string.Format("form-data; name=\"thumb\"; filename=\"{0}\"", Path.GetFileName(thumbPath)));
                mpc.Add(thumbContentStream);
            }
            var url = "https://bim360field.autodesk.com/api/attachments";
            var resp = url
                        .PostAsync(mpc)
                        .Result;
            return resp;
        }
