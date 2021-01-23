    using ClearQuestOleServer;
    using System.Runtime.InteropServices;
    
    private void button1_Click(object sender, RibbonControlEventArgs e)
            {
                String defectNumber = "L12345678";
                Session cqsession = new Session();
    
                try
                {
                    cqsession.UserLogon(loginName, password, databaseName, sessionType, databaseSet);
                    ClearQuestOleServer.IOAdEntity defect = cqsession.GetEntity("defect", defectNumber) as ClearQuestOleServer.IOAdEntity;
    
                    cqsession.EditEntity(defect, "modify");
    
                    String val = defect.GetFieldValue("User Data") as String;
                    defect.SetFieldValue("UserData", "Test String");
    
                    string result = defect.Validate();
                    //if (defect.Validate() == null)
                    //defect.Commit();
                    //else
                    //defect.Revert();
                }
                catch (Exception error)
                {
                    int a = 1;
                }
            }
