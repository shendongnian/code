     public void getstyle(Word.Document doc) 
            {
                if (doc.Application.Options.SaveInterval==10)
                {
                    doc.Application.Options.SaveInterval = 0;
                }
                
            }
