    public class CVResult: ActionResult
    {
        private readonly CV _cv;
    
        public CVResult(CV cv)
        {
            _cv = cv;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            var filename = "CV - " + _cv.firstname + " " + _cv.name + " - " + _cv.creationdate.ToString("dd MM yyyy") + ".docx";
    
            var cd = new ContentDisposition
            {
                Inline = false,
                FileName = filename
            };
    
            using (var doc = DocX.Create(response.OutputStream))
            {
                Paragraph title = doc.InsertParagraph();
                title.Append(_cv.firstname + " " + _cv.name);
                doc.Save();
            }
        }
    }
