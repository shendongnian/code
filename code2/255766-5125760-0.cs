      public void InserStudentByXML(string uri,Student objStudent)
            {
                XDocument xmlDoc = XDocument.Load(uri);
                XElement XParentElement = new XElement("Students");
                int studentId = 0;
                studentId = xmlDoc.Descendants("Student").Max(id => (int)id.Attribute("StudentId"));
                studentId += 1;
                objStudent.StudentId = studentId;         
                xmlDoc.Element("Students").Add(
                    new XElement("Student",
                                            new XElement("Name", objStudent.StudeentName),
                                            new XElement("Address", objStudent.Address),
                                            new XElement("StudentMobile", objStudent.StudentMobile),
                                            new XElement("EmailId", objStudent.StudentEmailId),
                                            new XElement("ParentName", objStudent.ParentName),
                                            new XElement("ParentMobile", objStudent.ParentMobile),
                                            new XElement("Physics", objStudent.Physics),
                                            new XElement("Chemistry", objStudent.Chemistry),
                                            new XElement("Mathemeatics", objStudent.Mathemeatics),
                                            new XElement("Biology", objStudent.Biology),
                                            new XElement("RegistrationDate", objStudent.RegistrationDate),
                                            new XAttribute("StudentId", objStudent.StudentId)
                                           
                                    ));
                xmlDoc.Save(uri); 
            }
