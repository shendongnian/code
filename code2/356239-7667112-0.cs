     public List<string> CompareInsee(string TheZone, List<object> InseList)
        {
            try
            {
                List<string> TempDict = new List<string>();
                RempliClientInseExtracted(TheZone, ref NomTable);
                DataTable TempDS = oClInse.Get_All_Inse(NomTable);
                DataRow drFound;
                DataColumn[] dcPk = new DataColumn[1];             
                // Set Primary Key
                dcPk[0] = TempDS.Columns["NO_INSEE"];
                TempDS.PrimaryKey = dcPk;
                // Find the Row specified in txtFindArg
               
               foreach (var oItem in InseList)
               {
                   drFound = TempDS.Rows.Find(oItem);
                   if (drFound != null) TempDict.Add( oItem.ToString()); 
               }
               return TempDict;
              
            }
            catch (Exception excThrown)
            {
                if (!excThrown.Message.StartsWith("Err_")) { throw new Exception("Err_BL_ReadAllClientInsee", excThrown); }
                else { throw new Exception(excThrown.Message, excThrown); }
            }
        }
