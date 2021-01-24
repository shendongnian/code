    ReportDocument reportDocument = new ReportDocument();
                    ParameterFields paramFields = new ParameterFields();
                    ParameterField paramField = new ParameterField();
                    ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
                    ParameterDiscreteValue paramDiscreteValue1 = new ParameterDiscreteValue();
                    ParameterField parameterField1 = new ParameterField();
                    ParameterDiscreteValue parameterDiscreteValue1 = new ParameterDiscreteValue();
                    ParameterFields parameterFields = new ParameterFields();
       parameterField1.Name = "@ORDER_ID";
       parameterDiscreteValue1.Value = (object)this.TXTORDERID.Text.ToString();
                                parameterField1.CurrentValues.Add((ParameterValue)parameterDiscreteValue1);
                                parameterFields.Add(parameterField1);
        
                                ParameterField parameterField2 = new ParameterField();
                                ParameterDiscreteValue parameterDiscreteValue2 = new ParameterDiscreteValue();
                                parameterField2.Name = "@deptid";
                                parameterDiscreteValue2.Value = (object)this.TXTDEPTID.Text.ToString();
                                parameterField2.CurrentValues.Add((ParameterValue)parameterDiscreteValue2);
                                parameterFields.Add(parameterField2);
                                this.CrystalReportViewer1.ParameterFieldInfo = parameterFields;
                                this.CrystalReportViewer1.ReuseParameterValuesOnRefresh = true;
                                this.CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
                                reportDocument.Load(this.Server.MapPath("~/RPT/RPT_CASH_RESULT.rpt"));
                                this.CrystalReportViewer1.ReportSource = (object)reportDocument;
                                reportDocument.SetDatabaseLogon("DB", "111");
        
                                ConnectionInfo connectionInfo = new ConnectionInfo();
                                connectionInfo.ServerName = "server";
                                connectionInfo.DatabaseName = "DBname";
                                connectionInfo.Password = "dbpass";
                                connectionInfo.UserID = "DBuser";
                                connectionInfo.Type = ConnectionInfoType.SQL;
                                connectionInfo.IntegratedSecurity = false;
                                for (int index = 0; index < this.CrystalReportViewer1.LogOnInfo.Count; ++index)
                                    this.CrystalReportViewer1.LogOnInfo[index].ConnectionInfo = connectionInfo;
