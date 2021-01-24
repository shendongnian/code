    using UnityEngine;
    using System.Collections;
    using UnityEngine.Networking;
    using System.Text;
    public class Login : MonoBehaviour
    {
        public string inputUserName;
        public string inputPassword;
        string loginURL = "http://192.168.10.89:8080/GameManage/userLogin/";
        private void Start()
        {
            StartCoroutine(login("09256358599", "123456789"));
        }
        IEnumerator login(string username, string password)
        {
            var json = "{\"phoneNumber\":\"" + username + "\",\"password\":\"" + password + "\"}";
            var request = new UnityWebRequest(loginURL, "POST");
            var bodyRaw = GetBytes(json);
            request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.Send();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogErrorFormat(this, "Upload failed with: {0} - {1}", request.responseCode, request.error);
            }
            else
            {
                Debug.Log("FORM UPLOAD COMPLETE");
                var results = request.downloadHandler.data; //this will contain the JSON data you 'll need
            }
        }
        private byte[] GetBytes(string json)
        {
            return Encoding.UTF8.GetBytes(json);
        }
    }
