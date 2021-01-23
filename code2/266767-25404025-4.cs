        ''' <summary>
        ''' Converts an array of strings to XML values.
        ''' </summary>
        ''' <remarks>Used to pass parameter values to the data store.</remarks>
        Public Shared Function ConvertToXML(xmlRootName As String, values() As String) As String
            'Note: XML values must be HTML encoded.
            Dim sb As New StringBuilder
            sb.AppendFormat("<{0}>", HttpUtility.HtmlEncode(xmlRootName))
            For Each value As String In values
                sb.AppendLine()
                sb.Append(vbTab)
                sb.AppendFormat("<value>{0}</value>", HttpUtility.HtmlEncode(value))
            Next
            sb.AppendLine()
            sb.AppendFormat("</{0}>", xmlRootName)
            Return sb.ToString
        End Function
