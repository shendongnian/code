    using (MemoryStream outFile = new MemoryStream())
                    {
                        var streamFile = await App.GraphClient.Me.Drive.Items[item.Id].Content.Request().GetAsync();
    
                        using(PdfDocument pdf = new PdfDocument(new PdfReader(streamFile), new PdfWriter(outFile)))
                        {
    
                            pdf.SetCloseWriter(false);
    
                            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, true);
    
                            IDictionary<String, PdfFormField> fields = form.GetFormFields();
    
                            PdfFormField toSet;
                            fields.TryGetValue("Full_Names", out toSet);
                            toSet.SetValue(Customer_Name.Text + " " + Customer_LName.Text);
    
                            fields.TryGetValue("Full_Names0", out toSet);
                            toSet.SetValue(Customer_Name.Text + " " + Customer_LName.Text);
    
                            fields.TryGetValue("Full_Names1", out toSet);
                            toSet.SetValue(Customer_Name.Text + " " + Customer_LName.Text);
    
                            fields.TryGetValue("Address0", out toSet);
                            toSet.SetValue(Address1.Text);
    
                            fields.TryGetValue("City0", out toSet);
                            toSet.SetValue(City.Text);
    
                            fields.TryGetValue("Province0", out toSet);
                            toSet.SetValue(Province.Text);
    
                            fields.TryGetValue("Phone0", out toSet);
                            toSet.SetValue(Phone2Main.Text);
    
                            fields.TryGetValue("Email0", out toSet);
                            toSet.SetValue(Email.Text);
    
                            form.FlattenFields();
                        }
    
                        outFile.Flush();
                        outFile.Position = 0;
    
                        await App.GraphClient.Me.Drive.Items[newFolder.Id].ItemWithPath(item.Name).Content.Request().PutAsync<DriveItem>(outFile);
                    }
