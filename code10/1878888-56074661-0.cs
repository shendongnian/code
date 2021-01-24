      DataTable dt = (DataTable)dataGridView1.DataSource;
      DataSet ds = new DataSet();
      DataSet ds1 = new DataSet();
      ds.Tables.Add(dt);
      ds1.Tables.Add(dt1);
                    DataTable dt1 = (DataTable)dataGridView2.DataSource;
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "XML|*.xml";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            ds.Merge(ds1);
                            ds.WriteXml(sfd.FileName);
                            //dt1.WriteXml(sfd.FileName);
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex);
                        }
                    }
