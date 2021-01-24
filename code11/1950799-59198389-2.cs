    public interface IGDriveApiV3Wrapper
    {
        string UploadFile(string filePath, string gDriveUploadDestinationFolderId = null);
        bool SetFilePermissions(string fileId, GDriveFileRole gDriveRole, GDriveFileType gDriveType);
        GDriveFile GetFileInfo(string fileId);
    }
----------
    public class GDriveApiV3NativeWrapper : IGDriveApiV3Wrapper
    {
        private const string GDriveFilesApiResumablePath = "https://www.googleapis.com/upload/drive/v3/files?uploadType=resumable";
        private const string GDriveTokenApiPath = "https://oauth2.googleapis.com/token";
        private static readonly HttpClient GDriveClient = new HttpClient { Timeout = Timeout.InfiniteTimeSpan };
        private readonly List<KeyValuePair<string, string>> _getTokenRequestContent;
        private static GDriveTokenInfo _gDriveTokenInfo;
        private static readonly object UpdateGDriveTokenInfoLocker = new object();
        public GDriveApiV3NativeWrapper(string gDriveApiClientId, string gDriveApiClientSecret, string gDriveApiRefreshToken)
        {
            _getTokenRequestContent = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", gDriveApiClientId),
                new KeyValuePair<string, string>("client_secret", gDriveApiClientSecret),
                new KeyValuePair<string, string>("refresh_token", gDriveApiRefreshToken),
                new KeyValuePair<string, string>("grant_type", "refresh_token")
            };
        }
        public string UploadFile(string filePath, string gDriveUploadDestinationFolderId = null)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
            FileInfo fileInfo;
            try
            {
                fileInfo = new FileInfo(filePath);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("File not valid.", nameof(filePath), ex);
            }
            if (!fileInfo.Exists)
                throw new ArgumentException("File not exists.", nameof(filePath));
            using (var initiateResumableUploadSessionRequest = new HttpRequestMessage(HttpMethod.Post, GDriveFilesApiResumablePath))
            {
                UpdateGDriveTokenInfo();
                initiateResumableUploadSessionRequest.Headers.Authorization = new AuthenticationHeaderValue(_gDriveTokenInfo.TokenType, _gDriveTokenInfo.AccessToken);
                var jsonContent = new JObject(
                    new JProperty("name", fileInfo.Name));
                if (!string.IsNullOrEmpty(gDriveUploadDestinationFolderId))
                {
                    jsonContent.Add(new JProperty("parents", new JArray { gDriveUploadDestinationFolderId }));
                }
                initiateResumableUploadSessionRequest.Content = new StringContent(jsonContent.ToString(), Encoding.UTF8, "application/json");
                var initiateResumableUploadSessionResponse = GDriveClient.SendAsync(initiateResumableUploadSessionRequest).Result;
                if (initiateResumableUploadSessionResponse.StatusCode != HttpStatusCode.OK)
                    throw new ExternalException(initiateResumableUploadSessionResponse.ToString());
                using (var uploadFileRequest = new HttpRequestMessage(HttpMethod.Put, initiateResumableUploadSessionResponse.Headers.Location))
                {
                    uploadFileRequest.Content = new ByteArrayContent(File.ReadAllBytes(filePath));
                    HttpResponseMessage uploadFileResponse;
                    uploadFileResponse = GDriveClient.SendAsync(uploadFileRequest).Result;
                    if (uploadFileResponse.StatusCode != HttpStatusCode.OK && uploadFileResponse.StatusCode != HttpStatusCode.Created)
                        throw new ExternalException(uploadFileResponse.ReasonPhrase);
                    var uploadFileResponseBody = uploadFileResponse.Content.ReadAsStringAsync().Result;
                    JObject uploadFileResponseJson = JObject.Parse(uploadFileResponseBody);
                    return uploadFileResponseJson["id"].ToString();
                }
            }
        }
        public bool SetFilePermissions(string fileId, GDriveFileRole gDriveFileRole, GDriveFileType gDriveFileType)
        {
            if (string.IsNullOrEmpty(fileId))
                throw new ArgumentException("Value cannot be null or empty.", nameof(fileId));
            using (var setFilePermissionsRequest = new HttpRequestMessage(HttpMethod.Post, $"https://www.googleapis.com/drive/v3/files/{fileId}/permissions"))
            {
                UpdateGDriveTokenInfo();
                setFilePermissionsRequest.Headers.Authorization = new AuthenticationHeaderValue(_gDriveTokenInfo.TokenType, _gDriveTokenInfo.AccessToken);
                var jsonContent2 = new JObject(
                    new JProperty("role", gDriveFileRole.ToString().ToLower()),
                    new JProperty("type", gDriveFileType.ToString().ToLower()));
                setFilePermissionsRequest.Content = new StringContent(jsonContent2.ToString(), Encoding.UTF8, "application/json");
                HttpResponseMessage setFilePermissionsResponse = GDriveClient.SendAsync(setFilePermissionsRequest).Result;
                if (setFilePermissionsResponse.StatusCode != HttpStatusCode.OK)
                    throw new ExternalException(setFilePermissionsResponse.ToString());
            }
            return true;
        }
        public GDriveFile GetFileInfo(string fileId)
        {
            using (var getFileInfoRequest = new HttpRequestMessage(HttpMethod.Get, $"https://www.googleapis.com/drive/v3/files/{fileId}?fields=name,webViewLink"))
            {
                UpdateGDriveTokenInfo();
                getFileInfoRequest.Headers.Authorization = new AuthenticationHeaderValue(_gDriveTokenInfo.TokenType, _gDriveTokenInfo.AccessToken);
                HttpResponseMessage getFileInfoResponse = GDriveClient.SendAsync(getFileInfoRequest).Result;
                if (getFileInfoResponse.StatusCode != HttpStatusCode.OK)
                    throw new ExternalException(getFileInfoResponse.ToString());
                var getFileInfoResponseBody = getFileInfoResponse.Content.ReadAsStringAsync().Result;
                JObject getFileInfoResponseJson = JObject.Parse(getFileInfoResponseBody);
                return new GDriveFile
                {
                    Id = fileId,
                    Name = getFileInfoResponseJson["name"].ToString(),
                    WebViewLink = getFileInfoResponseJson["webViewLink"].ToString()
                };
            }
        }
        private void UpdateGDriveTokenInfo()
        {
            lock (UpdateGDriveTokenInfoLocker)
            {
                if (_gDriveTokenInfo != null && !_gDriveTokenInfo.IsExpired())
                {
                    return;
                }
                using (var refreshTokenRequest = new HttpRequestMessage(HttpMethod.Post, GDriveTokenApiPath))
                {
                    refreshTokenRequest.Content = new FormUrlEncodedContent(_getTokenRequestContent);
                    var getTokenRequestResponse = GDriveClient.SendAsync(refreshTokenRequest).Result;
                    var jsonResponse = JObject.Parse(getTokenRequestResponse.Content.ReadAsStringAsync().Result);
                    _gDriveTokenInfo = new GDriveTokenInfo((string)jsonResponse["access_token"], (int)jsonResponse["expires_in"], (string)jsonResponse["token_type"]);
                }
            }
        }
