    public ActionResult CVToWord(int id) 
            {
                var CV = CVDAO.CV.Single(cv => cv.id == id);
                var filename = "CV - " + CV.firstname + " " + CV.name + " - " + CV.creationdate.ToString("dd MM yyyy") + ".docx";
    
                using (DocX doc = DocX.Create(filename)) 
                {
                    Paragraph title = doc.InsertParagraph();
                    title.Append(CV.firstname + " " + CV.name);
                    doc.Save();
                }
                
                System.IO.FileStream stream = new System.IO.FileStream(filename, System.IO.FileMode.Open);
                return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", filename);
            }
