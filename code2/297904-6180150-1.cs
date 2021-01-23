      string xml =
                    @"<?xml version='1.0' encoding='utf-8'?>
    <allstudents>
        <student>
            <rollno>8001</rollno>
            <name>AAAA</name>
        </student>
        <student>
            <rollno>8002</rollno>
            <name>BBBB</name>
        </student>
    </allstudents>";
    
                var studentsXml = XDocument.Parse(xml);
    
                var students = studentsXml.Element("allstudents").Elements("student").ToList();
    
                StringBuilder sb = new StringBuilder(500);
    
                sb.Append("<table>");
    
                foreach (var student in students)
                {
                    string rollNumber = student.Element("rollno") != null ? student.Element("rollno").Value : string.Empty;
                    string name = student.Element("name") != null ? student.Element("name").Value : string.Empty;
    
                    sb.Append("<tr>");
                    sb.Append("<td>&nbsp;</td>");
                    sb.Append("<td>Name</td>");
                    sb.Append("</tr>");
                    
                    sb.Append("<tr>");
                    sb.AppendFormat("<td><input type='checkbox' name='cbRoll' value='{0}' id='cbRoll{0}' /></td>", rollNumber);
                    sb.AppendFormat("<td>{0}</td>", name);
                    sb.Append("<tr/>");
                }
    
                sb.Append("</table>");
    
    ltrStudents.Text = sb.ToString();
