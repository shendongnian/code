            /// <exception cref="IOException"></exception>
        public static void DeleteObject(this AmazonS3Context context, string key)
        {
            context = null;
            AmazonS3Operation(context, ctx => ctx.Client.DeleteObject(
                new DeleteObjectRequest().WithBucketName(ctx.CurrentBucket)
                    .WithKey(key)));
        }
        /// <exception cref="IOException"></exception>
        private static void AmazonS3Operation(AmazonS3Context context, Action<AmazonS3Context> operation)
        {
            var shouldDispose = false;
            try
            {
                if (context == null)
                {
                    context = new AmazonS3Context();
                    shouldDispose = true;
                }
                operation(context);
            }
            catch (AmazonS3Exception e)
            {
                throw new IOException(e.Message, e);
            }
            finally
            {
                if (shouldDispose)
                    context.Dispose();
            }
        }
