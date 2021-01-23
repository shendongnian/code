    //Added reference to COM Microsoft DAO 3.6
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DAO.DBEngine dbEng = new DAO.DBEngine(); 
                DAO.Workspace ws = dbEng.CreateWorkspace("", "admin", "", DAO.WorkspaceTypeEnum.dbUseJet); 
                DAO.Database db = ws.OpenDatabase("z:\\docs\\dbfrom.mdb", false, false, "");
                DAO.TableDef tdf = db.TableDefs["Test"];
       
                DAO.Field fld = tdf.Fields["AYesNo"];
                //dbInteger  3 
                //accheckbox  106 
                DAO.Property prp = fld.CreateProperty("DisplayControl", 3,106);
                fld.Properties.Append(prp);
            }
        }
    }
