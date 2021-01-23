     public class pdfStatementController : Controller
    {
        Models.DYNAMICS_EXTEntities _db = new Models.DYNAMICS_EXTEntities();
        //
        // GET: /pdfStatement/
        public ActionResult SendPdfStatement(string InvoiceNumber)
        {
            try
            {
                InvoiceNumber = InvoiceNumber.Trim();
               
                List<Models.Statement> statementList = new List<Models.Statement>();
                //this is if you use entity framework
                {  
                   ObjectParameter[] parameters = new ObjectParameter[1];
                parameters[0] = new ObjectParameter("InvoiceNumber", InvoiceNumber);
                   statementList = _db.ExecuteFunction<Models.Statement>("uspInvoiceStatement", parameters).ToList<Models.Statement>();
                 }
                //others can simply use line like
                //statementList = GetStatementList(inviceNumber);
                pdfStatementController.WriteInTemplate(statementList);
                return RedirectToAction("Invoice", "Invoice", new { id = statementList.FirstOrDefault().Customer_ID.ToString().Trim() });
            }
            catch (Exception e)
            {
                return View("Error");
            }
           
        }
