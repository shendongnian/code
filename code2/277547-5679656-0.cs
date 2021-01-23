    public Stream LookupItem(Message requestXml)
        {
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
            string responseXml = "<whatever />";
            return new MemoryStream(Encoding.UTF8.GetBytes(responseXml ));
        }
