            try
            {
                if(wordApplication == null)  
                    wordApplication = new Word.Application(); 
                wordApplication.Visible = true;
                string filePath = myPath + fileName;
                WordApi.Document docx = wordApplication.Documents.Open(filePath);
            }
            catch (Exception ex)
            {
                MyLogger.Error(ex.ToString());
            }
