    private static AlternateView GetEmbeddedImage(string body)
        {
            var linkedResources = GetLinkedResources();
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(body, Encoding.UTF8, MediaTypeNames.Text.Html);
            foreach (var res in linkedResources)
            {
                alternateView.LinkedResources.Add(res);
            }
            return alternateView;
        }
        private static ICollection<LinkedResource> GetLinkedResources()
        {
            var linkedResources = new List<LinkedResource>();
            linkedResources.Add(new LinkedResource(@"imagepath")
            {
                ContentId = "HeaderId",
                TransferEncoding = TransferEncoding.Base64
            });
            linkedResources.Add(new LinkedResource(@"imagepath")
            {
                ContentId = "MapId",
                TransferEncoding = TransferEncoding.Base64
            });
            return linkedResources;
        }
