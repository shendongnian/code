                    e.Result = "";
                    //int count1 = 0;
                    int val = 6000;
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("ComputerName", typeof(String)));          //0
                    dt.Columns.Add(new DataColumn("IP", typeof(String)));            //1
                    dt.Columns.Add(new DataColumn("MAC", typeof(String)));       //2
                    dt.Columns.Add(new DataColumn("Descubierto", typeof(String)));  
                    for (int a = 1; a <= val; a++)
                     
                    {
                        counter.Text = Convert.ToString(a);
                        if (txtWorkGroupName.Text == "") return;
                        //DataTable dt = new DataTable();
                        //dt.Clear();
                            //3
                        //int i = 0;
                        try
                        {
                            // Datos del grupo WinNT://&&&&(Nombre del grupo de trabajo)
                            DirectoryEntry DomainEntry = new DirectoryEntry("WinNT://" + txtWorkGroupName.Text + "");
                            DomainEntry.Children.SchemaFilter.Add("Computer");
                            ///*************************************************
                            /// Interactuando con PC's dentro del mismo dominio
                            ///*************************************************
                            foreach (DirectoryEntry machine in DomainEntry.Children)
                            {
                                string strMachineName = machine.Name;
                                string strMACAddress = "";
                                IPAddress IPAddress;
                                DateTime discovered;
                                try
                                {
                                    IPAddress = getIPByName(machine.Name);
                                }
                                catch
                                {
                                    continue;
                                }//try/catch
                                ///*************************************************
                                /// Obtener Mac
                                ///*************************************************
                                strMACAddress = getMACAddress(IPAddress);
                                discovered = DateTime.Now;
                                ///*************************************************
                                /// Manejo de repeticiones en el grid
                                ///*************************************************
                                
                               bool isDuplicate;
                                
                                for(int nbRow = 0; nbRow < dt.Rows.Count; nbRow++)
                                {
                                    for(int nbRowCompare = nbRow; nbRowCompare < dt.Rows.Count; nbRowCompare++)
                                        {
                                            isDuplicate = true;
              for(int nbCol = 0; nbCol < dt.Rows[nbRow].Cells.Count; nbCol++)
                                    {
                    if(dt[nbCol, nbRow].Value != dt [nbCol, nbRowCompare])
                                                 {
                                 isDuplicate = false;
                              break;     //Exit for each column if they are not duplicate
                                                  }
                                             }
                                        if(isDuplicate)
                                         {
                                             MessageBox.Show("el valor esta duplicado");
                                         }
                                    }
                                }
                                
                                ///*************************************************
                                /// this is gonna BE fixed
                                ///*************************************************
                               
                                
                                
                                
                                DataRow dr = dt.NewRow();
                                dr[0] = machine.Name;
                                dr[1] = IPAddress;
                                dr[2] = strMACAddress;
                                dr[3] = Convert.ToString(discovered);
                                dt.Rows.Add(dr);
                                
                                
                                
                                dgvComputers1.DataSource = dt;
                                
                                
                                dgvComputers1.Refresh();
                                //dt.Columns(machine.Name).Unique = true;
                                //dt.Columns(IPAddress).Unique = true;
                                //dt.Columns(strMACAddress).Unique = true;
                               
                                
                            }//foreach loop
                            
                           
                           // DataView dv = new DataView();
                           // dv = dt;
                            
                            Thread.Sleep(2000);
                            //dt = ((DataView)this.dgvComputers1.DataSource).Table;
                            //dt.WriteXml(@"testermac.xml");
                            ///*************************************************
                            /// SETTING DATASOURCE
                            ///*************************************************
                            //  dgvComputers.DataSource = dt;
                            //goto factor;
                            //factor:
                            //  if (restart < 20)
                            //{
                            //  btnScan.PerformClick();
                            // restart = restart + restart++;
                            //counter.Text = Convert.ToString(restart);
                            //}
                        }//try/catch
                        catch (Exception ex)
                        {
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        if (backgroundWorker2.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("error:" + ex);
                    //tbmessage.Text += "se ha producido un error: " + ex + Environment.NewLine;
                    //tbmessage.SelectionStart = tbmessage.Text.Length;
                    //tbmessage.ScrollToCaret();
                }
                catch (NoNullAllowedException ex)
                {
                    MessageBox.Show("error:" + ex);
                }
                catch (AccessViolationException ex)
                {
                    MessageBox.Show("error:" + ex);
                }
            }
