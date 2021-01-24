    using Microsoft.Office.Interop.Outlook; 
                
    namespace YourNamespace
    {
       public class YourClass
       { 
        //Create a mail object 
        Microsoft.Office.Interop.Outlook.Application ol = new  Microsoft.Office.Interop.Outlook.Application(); 
        //Create a mail item 
        Microsoft.Office.Interop.Outlook.MailItem mailitem = ol.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem); 
        //Your mail subject text 
        mailitem.Subject = "SMART G's Auto Email Test"; 
        //Mail Recipient 
        mailitem.To = "smartg@smartg.com"; 
        //Mail Sub Recipient 
        mailitem.CC = "test@test.com"; 
        //Your E-Mail Text 
        mailitem.Body = "Dear Sir or Madam,\n\n" + 
       "Attached please find my great manual on how to save the world. Thank you for reading. + "\n\n"
        + "Kind regards" + "\n\n" + "Smart G"; 
        //Your mail attachment
        mailitem.Attachments.Add(<<path>> + <<documentName>>); 
        //Do you want me to show you the mail?                           
        mailitem.Display(true); //yes 
        //If you want to check the mail before sending it then do not use this.     
        mailitem.Send(); //automatically sends the mail before you can check it! (autosend) 
        //Notifcation 
        MessageBox.Show("Mail sent!")
        }
    }
