    OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == DialogResult.OK) //if there is a file choosen by the user  
            {
                object path = file.FileName; //get the path of the file  
                object readOnly = true;
                Spire.Doc.Document document = new Spire.Doc.Document(file.FileName);
                int index = 1;
                //Get Each Section of Document  
                foreach (Spire.Doc.Section section in document.Sections)
                {
                    //Get Each Paragraph of Section  
                    foreach (Spire.Doc.Documents.Paragraph paragraph in section.Paragraphs)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(paragraph.Text);//storing the text of word in string builder
                        Console.WriteLine(sb);
                        //Get Each Document Object of Paragraph Items  
                        foreach (DocumentObject docObject in paragraph.ChildObjects)
                        {
                            //If Type of Document Object is Picture, Extract.  
                            if (docObject.DocumentObjectType == DocumentObjectType.Picture)
                            {
                                DocPicture pic = docObject as DocPicture;
                                
                                String imgName = String.Format(@"E:\C#\OnlineExam\Question\{0}.png", index);
                                //Save Image  
                                pic.Image.Save(imgName, System.Drawing.Imaging.ImageFormat.Png);
                                index++;
                            }
                        }
                    }
                }}
