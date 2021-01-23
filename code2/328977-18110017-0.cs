        Public Class MyRepeater : Inherits Repeater
            Protected Overrides Sub Render(writer As System.Web.UI.HtmlTextWriter)
            Using htmlwriter As New HtmlTextWriter(New System.IO.StringWriter())
               MyBase.Render(htmlwriter)
               Dim html As String = htmlwriter.InnerWriter.ToString()
               html = Regex.Replace(html, "(?<=[^])\t{2,}|(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,11}(?=[<])|(?=[\n])\s{2,}", String.Empty)
               html = Regex.Replace(html, "[ \f\r\t\v]?([\n\xFE\xFF/{}[\];,<>*%&|^!~?:=])[\f\r\t\v]?", "$1")
               html = html.Replace(";\n", ";")
               writer.Write(html.Trim())
             End Using
          End Sub
       End Class
