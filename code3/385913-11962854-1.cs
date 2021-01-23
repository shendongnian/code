    Dim oWebClient As System.Net.WebClient = Nothing
    Dim data() As Byte
    try
     oWebClient = New System.Net.WebClient
     data = oWebClient.DownloadData(pdfurl)
    //add Response.AddHeader stuff here e.g.
     Response.AddHeader("Content-Length", data.Length.ToString)
     Response.BinaryWrite(data)
