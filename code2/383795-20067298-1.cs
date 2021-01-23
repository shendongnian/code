      XElement xEmp = XElement.Load(@"C://Users//Khulu//Documents//Visual Studio 2012//Projects//AMD//Schedule//ToDo.xml");
                //
                xEmp.Add(
                         new XElement("ToDo",
                          new XElement("Item", item),
                           new XElement("date", date),
                            new XElement("time", time),
                            new XElement("due", due),
                            new XElement("description", description))
                );
                xEmp.Save(@"C://Users//Khulu//Documents//Visual Studio 2012//Projects//AMD//Schedule//ToDo.xml");`  XElement xEmp = XElement.Load(@"C://Users//Khulu//Documents//Visual Studio 2012//Projects//AMD//Schedule//ToDo.xml");
                //
                xEmp.Add(
                         new XElement("ToDo",
                          new XElement("Item", item),
                           new XElement("date", date),
                            new XElement("time", time),
                            new XElement("due", due),
                            new XElement("description", description))
                );
                xEmp.Save(@"C://Users//Khulu//Documents//Visual Studio 2012//Projects//AMD//Schedule//ToDo.xml");`
