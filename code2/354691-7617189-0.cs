        private const string AWS_ACL_HEADER = "x-amz-acl";
        private static string ToACLString(S3ACLType acl) {
            switch (acl) {
                case S3ACLType.AuthenticatedRead:
                    return "authenticated-read";
                case S3ACLType.BucketOwnerFullControl:
                    return "bucket-owner-full-control";
                case S3ACLType.BucketOwnerRead:
                    return "bucket-owner-read";
                case S3ACLType.Private:
                    return "private";
                case S3ACLType.PublicRead:
                    return "public-read";
                case S3ACLType.PublicReadWrite:
                    return "public-read-write";
		        default: return "";
            }
        }
        public void Put(string bucketName, string id, byte[] bytes, string contentType, S3ACLType acl) {
            string uri = String.Format("https://{0}/{1}", BASE_SERVICE_URL, bucketName.ToLower());
            DreamMessage msg = DreamMessage.Ok(MimeType.BINARY, bytes);
            msg.Headers[DreamHeaders.CONTENT_TYPE] = contentType;
            msg.Headers[DreamHeaders.EXPECT] = "100-continue";
            msg.Headers[AWS_ACL_HEADER] = ToACLString(acl);
            Plug s3Client = Plug.New(uri).WithPreHandler(S3AuthenticationHeader);
            s3Client.At(id).Put(msg);
        }
