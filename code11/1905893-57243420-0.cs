         public object Any(UploadImageRequest request)
         {
                if (Request.ContentLength > 10 * 1024 * 1024)
                {
                    return new HttpResult($"Image too large!", HttpStatusCode.RequestEntityTooLarge);
                }
                ...
         }
