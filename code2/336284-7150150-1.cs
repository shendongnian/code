        {
            FileUpload fu = FileUpload1; 
            if (fu.HasFile)  
            {
                 StreamReader reader = new StreamReader(fu.FileContent);
                                do
                                {
                                    string textLine = reader.ReadLine();
                                    // do your coding 
                                    //Loop trough txt file and add lines to ListBox1  
                                }
                                while (reader.Peek() != -1);
                                reader.Close();
                            }
                            }
        } 
