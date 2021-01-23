    try
           {
               
                    if (txtFilePath.Text == pdfFilepath )
                    {
                        byte [] b=File .ReadAllBytes (pdfFilepath);
                        SqlConnection con1=Connection.Conn();
                        SqlCommand cmd=new SqlCommand ("insert into tbl_Document(Company_Id,FileNo,PdfFile)values(@cid,@fno,@file)",con1);
                        cmd .Parameters .AddWithValue("@cid",txtCompanyId.Text);
                        cmd .Parameters .AddWithValue("@fno",txtFileNumber.Text);
                        cmd .Parameters .AddWithValue("@file",b);
                        con1.Open();
                        cmd .ExecuteNonQuery();
                        con1.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please give a valid file address.");
                        this.Dispose();
                    }
                
           }
            catch
            { 
                MessageBox.Show("Unable to Process.");
                this.Dispose();
            }
