    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using UnityEngine;
    public class UrlOpener : MonoBehaviour
    {
        public string imageaddress;
        public void Open()
        {
            using (var client = new WebClient())
            {
                string json = client.DownloadString("http://www.example.com/some.json");
                var img= JsonUtility.FromJson<ArtImage>(json);
                imageaddress = img.imageurl;
            }
        }
    }
