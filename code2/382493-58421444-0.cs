    <Runtime.CompilerServices.Extension()>
    Public Function XslTransform(XDocument As XDocument, xslFile As String) As XDocument
        If String.IsNullOrWhiteSpace(xslFile) Then
            Try
                Dim ProcessingInstructions As IEnumerable(Of XElement) = From Node As XNode In XDocument.Nodes
                                                                         Where Node.NodeType = Xml.XmlNodeType.ProcessingInstruction
                                                                         Select Node
                xslFile = ProcessingInstructions.Value
            Catch ex As Exception
                ex.WriteToLog(EventLogEntryType.Warning)
            End Try
        End If
        XslTransform = New XDocument
        Try
            Dim XslCompiledTransform As New Xml.Xsl.XslCompiledTransform()
            XslCompiledTransform.Load(xslFile)
            Using XmlWriter As Xml.XmlWriter = XslTransform.CreateWriter
                Using XMLreader As Xml.XmlReader = XDocument.CreateReader()
                    XslCompiledTransform.Transform(XMLreader, XmlWriter)
                    XmlWriter.Close()
                End Using
            End Using
            Return XslTransform
        Catch ex As Exception
            ex.WriteToLog
            XslTransform = New XDocument()
            Throw New ArgumentException("XDocument failted to transform using " & xslFile, ex)
        End Try
    End Function
