     if (textBox1.Text != "")
                        {
                        //just Intlization Object's Here n Access Data using .xsd in Project
                            DataSet1.DataTable2DataTable dtcity = null;
                            DataSet1TableAdapters.DataTable2TableAdapter adpt = null;
                            ParameterFields myParams = null;
                            ParameterField name = null;
                            CrystalReport1 rpt = null;
                            ParameterDiscreteValue valYear = null;
                          try
                            {
    // For Get Data For DB
                                dtcity = new DataSet1.DataTable2DataTable();
                                adpt = new DataSet1TableAdapters.DataTable2TableAdapter();
                                dtcity = adpt.GetStateNCityData();
                                rpt = new CrystalReport1();
                   rpt.Database.Tables["DataTable2"].SetDataSource(dtcity.Copy() as DataTable);
    //For Get Data For DB
    //Add Paramater 
                                myParams = new ParameterFields();
                                name = new ParameterField();
                                valYear = new ParameterDiscreteValue();
                                name.ParameterFieldName = "@textName";
                                valYear.Value = textBox1.Text;
                                name.CurrentValues.Add(valYear);
                                myParams.Add(name);
                                crystalReportViewer1.ParameterFieldInfo = myParams;
    //Add Paramater 
                                crystalReportViewer1.ReportSource = rpt;
                            }
                            catch (Exception ex)
                            {
                            }
                            finally { }
              }
                        else
                        {
                            MessageBox.Show("Please Enter Name");
                            textBox1.Focus();
                        }
