    catch (Exception ex)
    {
        byte[] exceptionData;
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter(
                null, new StreamingContext(StreamingContextStates.Persistence));
            formatter.Serialize(stream, ex);
            exceptionData = stream.ToArray();
        }
        using (WebClient client = new WebClient())
        {
            Uri handler = new Uri(ApplicationUri, "TransferException.axd");
    #if DEBUG
            ServicePointManager.ServerCertificateValidationCallback +=
                new RemoteCertificateValidationCallback(BypassAllCertificateStuff);
    #endif
            client.UploadData(handler, exceptionData);
        }
    }
