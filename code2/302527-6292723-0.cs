        Public Sub Save(ByVal st As Stream, Optional ByVal AttachComment As Boolean = True)
        Dim xtw As New XmlTextWriter(st, Text.Encoding.GetEncoding("ISO-8859-1"))
        xtw.Formatting = Formatting.Indented
        xtw.WriteStartDocument()
        'Header.
        If AttachComment Then
            xtw.WriteComment(GenerateCreationComment())
        End If
        xtw.WriteStartElement("SektionsdataFile")
        xtw.WriteStartElement("Header")
        WriteStringElement(xtw, "FileType", "Settings")
        WriteStringElement(xtw, "FormatVersion", CurrentFormatVersion)
        xtw.WriteEndElement()
        'Settings.
        xtw.WriteStartElement("Settings")
        SaveSettingsCategory(xtw, Application)
        SaveSettingsCategory(xtw, Behaviour)
        SaveSettingsCategory(xtw, Calculation)
        SaveSettingsCategory(xtw, Forms)
        SaveSettingsCategory(xtw, Hardware)
        SaveSettingsCategory(xtw, Layout)
        SaveSettingsCategory(xtw, License)
        SaveSettingsCategory(xtw, Paths)
        SaveSettingsCategory(xtw, Printing)
        xtw.WriteEndElement()
        xtw.WriteEndElement()
        xtw.WriteEndDocument()
        xtw.Flush()
        xtw.Close()
    End Sub
