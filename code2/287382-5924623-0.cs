    using System;
    using System.IO;
    using System.Net;
    
    WebClient webClient = new WebClient();
    webClient.Credentials = new NetworkCredential("username", "password", "domain");
    webClient.DownloadFile("https://servername/path/documentToDownload.txt", "localPathToSaveFile");
