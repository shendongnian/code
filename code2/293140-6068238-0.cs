    `private const string accessKeyId = "REMOVED";
        private const string secretAccessKey = "REMOVED";
        private static DateTime GetTimeStamp(DateTime myTime)
        {
            DateTime myUniversalTime = myTime.ToUniversalTime();
            DateTime myNewTime = new DateTime(myUniversalTime.Year,
            myUniversalTime.Month, myUniversalTime.Day,
            myUniversalTime.Hour, myUniversalTime.Minute,
            myUniversalTime.Second, myUniversalTime.Millisecond);
    
            return myNewTime;
        }
        private static string GetSignature(string secretAccessKey, string strOperation, DateTime myTime)
        {
            Encoding myEncoding = new UTF8Encoding();
    
            // Create the source string which is used to create the digest
            string mySource = "AmazonS3" + strOperation + FormatTimeStamp(myTime);
    
            // Create a new Cryptography class using the 
            // Secret Access Key as the key
            HMACSHA1 myCrypto = new HMACSHA1(myEncoding.GetBytes(secretAccessKey));
    
            // Convert the source string to an array of bytes
            char[] mySourceArray = mySource.ToCharArray();
            // Convert the source to a UTF8 encoded array of bytes
            byte[] myUTF8Bytes = myEncoding.GetBytes(mySourceArray);
            // Calculate the digest 
            byte[] strDigest = myCrypto.ComputeHash(myUTF8Bytes);
            return Convert.ToBase64String(strDigest);
        }
        private static string FormatTimeStamp(DateTime myTime)
        {
            DateTime myUniversalTime = myTime.ToUniversalTime();
            return myUniversalTime.ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", System.Globalization.CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Upload Images.
        /// </summary>
        /// <param name="a">Ex. FileUpload1.PostedFile.ContentType</param>
        /// <param name="b">Ex. FileUpload1.PostedFile.FileName</param>
        /// <param name="c">Ex. FileUpload1.FileBytes</param>
        /// <param name="d">Ex. FileUpload1.FileBytes.Length</param>
        /// <param name="id">The ID for this Product Group</param>
        public void UploadImage_ProductGroup(string a, string b, byte[] c, long d, int id)
        {
            AmazonS3 myS3 = new AmazonS3();
            DateTime myTime = DateTime.Now;
    
            // Create a signature for this operation
            string strMySignature = GetSignature(
            secretAccessKey,
            "PutObjectInline",
            myTime);
    
            // Create a new Access grant for anonymous users.
            Grant myGrant = new Grant();
            Grant[] myGrants = new Grant[1];
    
            // Setup Access control, allow Read access to all
            Group myGroup = new Group();
            myGroup.URI = "http://acs.amazonaws.com/groups/global/AllUsers";
            myGrant.Grantee = myGroup;
            myGrant.Permission = Permission.READ;
            myGrants[0] = myGrant;
    
            // Setup some metadata to indicate the content type 
            MetadataEntry myContentType = new MetadataEntry();
            myContentType.Name = "ContentType";
            myContentType.Value = a;
    
            MetadataEntry[] myMetaData = new MetadataEntry[1];
            myMetaData[0] = myContentType;
    
            //Format the file name to prepend thumbnail before the file extension.
          /*  int lastIndex = b.LastIndexOf('.');
            string fileName = b.Remove(lastIndex);
            string ext = b.Remove(0, lastIndex);
            string thumbPath = string.Format("images/public/{0}thumb{1}",fileName,ext);
            //Resize the thumbnail
            */
            
            
            
            // Finally upload the object
            PutObjectResult myResult = myS3.PutObjectInline(
                "mywebsite",
            "images/public/" + b,
                myMetaData,
                c,
                d,
                myGrants,
                StorageClass.STANDARD,
                true,
                accessKeyId,
                GetTimeStamp(myTime),
                true,
                strMySignature, null
            );`
