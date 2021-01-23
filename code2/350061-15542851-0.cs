                ThreadPool.QueueUserWorkItem(bcl =>
                      {
                          var bcList = (List<BarcodeColumn>)bcl;
                          IAsyncResult iftAR = this.dataGridView1.BeginInvoke((MethodInvoker)delegate
                            {
                                int x = this.dataGridView1.Rows[0].Cells.Count - 1;
                                for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
                                {
                                    try
                                    {
                                       string imgPath = bcList[i].GifPath;
                                       Image bmpImage = Image.FromFile(imgPath);
                                       this.dataGridView1.Rows[i].Cells[x].Value =bmpImage;
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                            }); 
                          while (!iftAR.IsCompleted) { /* wait this*/  }
                      }, barcodeList);
