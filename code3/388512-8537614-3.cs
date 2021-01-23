    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using System.Data;
    using System.Data.Objects;
    using System.IO;
    using iTextSharp;
    using iTextSharp.text;
    using iTextSharp.text.html;
    using iTextSharp.text.pdf;
    using iTextSharp.text.xml;
    
    namespace InvoiceSearchTool.Controllers
    
    {
    
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
    public static void WriteInTemplate(List<Models.Statement> statementList)
        {
            try
            {
                string invoiceNumber = statementList.FirstOrDefault().Invoice.ToString().Trim();
                     
                using (Document document = new Document())
                {
                    FileStream fileStream = new FileStream(HostingEnvironment.MapPath("~/Content/reports/" + invoiceNumber + ".pdf"), FileMode.Create);
                    using (PdfSmartCopy smartCopy = new PdfSmartCopy(document, fileStream))
                    {
                        document.Open();
                        PdfReader pdfReader = new PdfReader(HostingEnvironment.MapPath("~/Content/InvoiceTemplate/invoiceTemplate.pdf"));
                                using (var memoryStream = new MemoryStream())
                                {
                                    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream))
                                    {
                                        string month = null;
                                        string day = null;
                                        string year = null;
                                        AcroFields pdfFields = pdfStamper.AcroFields;
                                        {//billing address
                                            pdfFields.SetField("BillToCompany", statementList.FirstOrDefault().BillToCompany.ToString().Trim().ToUpper());
                                            pdfFields.SetField("BillToContact", statementList.FirstOrDefault().BillToContact.ToString().Trim().ToUpper());
                                            pdfFields.SetField("ShipToCompany", statementList.FirstOrDefault().ShipToCompany.ToString().Trim().ToUpper());
                                            pdfFields.SetField("ShipToContact", statementList.FirstOrDefault().ShipToContact.ToString().Trim().ToUpper());
                                            pdfFields.SetField("PONumber", statementList.FirstOrDefault().PurchaseOrderNo.ToString().Trim());
                                            pdfFields.SetField("OrderNumber", statementList.FirstOrDefault().Order_Number.ToString().Trim());
                                            pdfFields.SetField("ShippingMethod", statementList.FirstOrDefault().Shipping_Method.ToString().Trim());
                                            pdfFields.SetField("PaymentTerms", statementList.FirstOrDefault().Payment_Terms.ToString().Trim());
                                       }
                                       pdfStamper.FormFlattening = true; // generate a flat PDF 
                                    }
                                    pdfReader = new PdfReader(memoryStream.ToArray());
                                    smartCopy.AddPage(smartCopy.GetImportedPage(pdfReader, 1));
                                }
                    }
                }
                    
                emailController.CreateMessageWithAttachment(invoiceNumber);
            }
            catch (Exception e)
            {
            }
        }
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using System.Net;
    using System.Net.Mail;
    using System.Web.Hosting;
    using System.Net.NetworkInformation;
    using System.Data.Objects;
    
    namespace InvoiceSearchTool.Controllers
    {
    
     public class emailController : Controller
    
     {
        //
        // GET: /email/
        public static void CreateMessageWithAttachment(string invoiceNumber)
        {
            try
            {
                Outlook.Application oApp = new Outlook.Application();
                Outlook.MailItem email = (Outlook.MailItem)(oApp.CreateItem(Outlook.OlItemType.olMailItem));
                Models.DYNAMICS_EXTEntities _db = new Models.DYNAMICS_EXTEntities();
                string recipient = null;
                string messageBody = null;
                #region set email recipients
                {
                    ObjectParameter[] parameters = new ObjectParameter[1];
                    parameters[0] = new ObjectParameter("InvoiceNumber", invoiceNumber);
                    List<Models.EmailAddress> emailList = _db.ExecuteFunction<Models.EmailAddress>("uspGetEmailAddress", parameters).ToList<Models.EmailAddress>();
                    if(!string.IsNullOrEmpty(emailList[0].Email.ToString()))
                        recipient = emailList[0].Email.ToString().Trim();
                    else
                        recipient = " ";
                    email.Recipients.Add(recipient);
                }
                #endregion
                //email subject                 
                email.Subject = "Invoice # " + invoiceNumber;
                #region set email Text
                {
                    Models.EmailText emailText = _db.ExecuteFunction<Models.EmailText>("uspEmailText").SingleOrDefault();
                    messageBody = emailText.EmailTextLine1.ToString().Trim() + "\n\n\n\n\n\n\n\n\n";
                    messageBody += emailText.EmailTextLine2.ToString().Trim() + "\n";
                    messageBody += emailText.EmailTextLine3.ToString().Trim();
                    email.Body = messageBody;
                }
                #endregion
                #region email attachment
                {
                    string fileName = invoiceNumber.Trim();
                    string filePath = HostingEnvironment.MapPath("~/Content/reports/");
                    filePath = filePath + fileName + ".pdf";
                    fileName += ".pdf";
                    int iPosition = (int)email.Body.Length + 1;
                    int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                    Outlook.Attachment oAttach = email.Attachments.Add(filePath, iAttachType, iPosition, fileName);
                }
                #endregion
                
                email.Display();
                //uncomment below line to SendAutomatedEmail emails atomaticallly
                //((Outlook.MailItem)email).Send(); 
            }
            catch (Exception e)
            {
            }
        }
