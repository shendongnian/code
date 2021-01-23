        Dim webBodyFormatMessageProp As Channels.WebBodyFormatMessageProperty
        Dim contentType As String
        Dim serializer As XmlObjectSerializer
        If WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json Then
            webBodyFormatMessageProp = New System.ServiceModel.Channels.WebBodyFormatMessageProperty(System.ServiceModel.Channels.WebContentFormat.Json)
            contentType = "application/json"
            serializer = New DataContractJsonSerializer(GetType(MyErroClass))
        Else
            webBodyFormatMessageProp = New System.ServiceModel.Channels.WebBodyFormatMessageProperty(System.ServiceModel.Channels.WebContentFormat.Xml)
            contentType = "text/xml"
            serializer = New DataContractSerializer(GetType(MyErroClass))
        End If
        Dim detail = faultException.[GetType]().GetProperty("Detail").GetGetMethod().Invoke(faultException, Nothing)
        fault = System.ServiceModel.Channels.Message.CreateMessage(version, "", detail, serializer)
        fault.Properties.Add(System.ServiceModel.Channels.WebBodyFormatMessageProperty.Name, webBodyFormatMessageProp)
        Dim httpResponseMessageProp = New System.ServiceModel.Channels.HttpResponseMessageProperty()
        httpResponseMessageProp.Headers(System.Net.HttpResponseHeader.ContentType) = contentType
        httpResponseMessageProp.StatusCode = System.Net.HttpStatusCode.OK
        httpResponseMessageProp.StatusDescription = [error].Message
        fault.Properties.Add(System.ServiceModel.Channels.HttpResponseMessageProperty.Name, httpResponseMessageProp)
