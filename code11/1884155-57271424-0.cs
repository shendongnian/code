                                case "eng":
                                    MainForm MainForm2 = new MainForm();
                                    ((Control)MainForm2.tabPage1).Enabled = true;
                                    MainForm2.LoadDataParts();
                                    MainForm2.DataGridCount();
                                    ((Control)MainForm2.tabPage2).Enabled = false;
                                    ((Control)MainForm2.tabPage3).Enabled = false;
                                    ((Control)MainForm2.tabPage4).Enabled = false;
                                    ((Control)MainForm2.tabPage5).Enabled = false;
                                    MainForm2.btnCB_Add.Enabled = false;
                                    MainForm2.button10.Enabled = false;
                                    MainForm2.btnCD_Delete.Enabled = false;
                                    MainForm2.dataGridView5.Visible = false;
                                    MainForm2.dataGridView7.Visible = false;
                                    MainForm2.dataGridView1.CellDoubleClick -= new DataGridViewCellEventHandler(MainForm2.DataGridView1_CellDoubleClick);
                                    MainForm2.Show();
                                    break;
