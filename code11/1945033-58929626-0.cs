    public static bool Layout_Preview(string ReportName, string First_Parameter)
                    {
                        Recordset oRS = (Recordset)SBOC_SAP.G_DI_Company.GetBusinessObject(BoObjectTypes.BoRecordset);
                        oRS.DoQuery("SELECT MenuUID FROM OCMN WHERE Name = '" + ReportName + "' AND Type = 'C'");
                        SAPbouiCOM.Form form = null;
                        if (oRS.RecordCount > 0)
                        {
                            string MenuID = oRS.Fields.Item(0).Value.ToString();
                            SBOC_SAP.G_UI_Application.ActivateMenuItem(MenuID);
                            form = SBOC_SAP.G_UI_Application.Forms.ActiveForm;
                            ((EditText)form.Items.Item("1000003").Specific).String = First_Parameter;
                            form.Items.Item("1").Click(BoCellClickType.ct_Regular);
                            return true; 
                        }
                        else
                        {
                            SBOC_SAP.G_UI_Application.MessageBox("Report layout 'ReportName' not found.", 0, "OK", null, null);
                            return false;
                        }
                        
                    }
