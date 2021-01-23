    System.Text.StringBuilder objSB = new System.Text.StringBuilder();
        System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo("d:\\");
        objSB.Append("<table>");
        objSB.Append("<tr><td>FileName</td>" + 
                     "<td>Last Access</td>" + 
                     "<td>Last Write</td>" + 
                     "<td>Attributes</td>" + 
                     "<td>Length(Byte)</td><td>Extension</td></tr>");
        foreach (System.IO.FileInfo objFile in directory.GetFiles("*.*"))
        {
            objSB.Append("<tr>");
            objSB.Append("<td>");
            objSB.Append(objFile.Name);
            objSB.Append("</td>");
            objSB.Append("<td>");
            objSB.Append(objFile.LastAccessTime);
            objSB.Append("</td>");
            objSB.Append("<td>");
            objSB.Append(objFile.LastWriteTime);
            objSB.Append("</td>");
            objSB.Append("<td>");
            objSB.Append(objFile.Attributes);
            objSB.Append("</td>");
            objSB.Append("<td>");
            objSB.Append(objFile.Length);
            objSB.Append("</td>");
            objSB.Append("<td>");
            objSB.Append(objFile.Extension);
            objSB.Append("</td>");
           
            objSB.Append("</tr>");
        }
        objSB.Append("</table>");
        Response.Write(objSB.ToString());
