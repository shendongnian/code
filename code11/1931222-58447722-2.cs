    private async Task<DialogTurnResult> UploadCodeAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            List<Attachment> attachments = (List<Attachment>)stepContext.Result;
            string replyText = string.Empty;
            foreach (var file in attachments)
            {
                // Determine where the file is hosted.
                var remoteFileUrl = file.ContentUrl;
                // Save the attachment to the system temp directory.
                var localFileName = Path.Combine(Path.GetTempPath(), file.Name);
                // Download the actual attachment
                using (var webClient = new WebClient())
                {
                    webClient.DownloadFile(remoteFileUrl, localFileName);
                }
                replyText += $"Attachment \"{file.Name}\"" +
                             $" has been received and saved to \"{localFileName}\"\r\n";
            }}
