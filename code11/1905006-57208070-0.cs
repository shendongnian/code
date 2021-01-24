    public class DictionaryServiceDouble : Dictionary<string, string>, IService
    {
        public string UploadText(string bucketName, string blobName, string text)
        {
            this[GetKey(bucketName, blobName)] = text;
            return text; // Is this what it's supposed to return?
        }
        public string DownloadText(string bucketName, string blobName)
        {
            // This is a little bit problematic if you want to test the behavior
            // when downloading something that doesn't exist.
            // This will work fine on the happy path. But on the "sad" path
            // this doesn't ensure that the double will behave like the real
            // implementation. 
            return this[GetKey(bucketName, blobName)];
        }
        public bool IsExistent(string bucketName, string blobName)
        {
            return ContainsKey(GetKey(bucketName, blobName));
        }
        private string GetKey(string bucketName, string blobName) => $"{bucketName}:{blobName}";
    }
