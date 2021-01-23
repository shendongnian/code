    if (!string.IsNullOrEmpty(BodyImageFileFullName))
            {
                var leftImageLink = new LinkedResource(BodyImageFileFullName, "image/jpg")
                {
                    ContentId = "ImageGM_left",
                    TransferEncoding = TransferEncoding.Base64
                };
                htmlView.LinkedResources.Add(leftImageLink);
            }
