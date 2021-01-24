[HttpGet]
public FileResult GetVisaAproveFile(string id)
{
  //skip content
  //Put your PDF in MemoryStream 
  MemoryStream msResult = ReadPDF();
  
  var fileResult = new FileStreamResult(msResult, "application/pdf");
  Response.AddHeader("Content-Disposition", string.Format("inline; filename={0}.pdf", id));
  return fileResult;
}
