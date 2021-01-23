    using (var client = new UpdatedOutlookServiceReferenceAPI.OutlookServiceSoapClient("OutlookServiceSoap"))
    {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12;
        var result = client.UploadAttachmentBase64(GUID, FinalFileName, fileURL);
        if (result == true)
        {
            resultFlag = true;
        }
        else
        {
            resultFlag = false;
        }
        LogWriter.LogWrite1("resultFlag : " + resultFlag);
    }
