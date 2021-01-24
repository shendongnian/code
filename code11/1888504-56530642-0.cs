    public class S3Path : IS3Path
    {
        private const string _s3PathRegex = @"[s|S]3:\/\/(?<bucket>[^\/]*)\/(?<key>.*)";
    
        public S3Path(string s3Path)
        {
            Path = s3Path;
    
            var rx = new Regex(_s3PathRegex).Match(s3Path);
    
            if (!rx.Success || rx.Groups.Count != 3)
                throw new Exception($"the S3 Path '{s3Path}' is wrong.");
    
            BucketName = rx.Groups[1].Value;
            Key = rx.Groups[2].Value;
        }
    
        public string Path { get; }
    
        public string BucketName { get; }
    
        public string Key { get; }
    }
