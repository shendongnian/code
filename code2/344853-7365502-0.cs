    using System;
    using Outlook = Microsoft.Office.Interop.Outlook;
    
    namespace Outlook_SendMailItem
    {
    	public class Class1
    	{
    		public static int Main(string[]args)
    		{
    			try
    			{
    				// Create the Outlook application by using inline initialization.
    				Outlook.Application oApp = new Outlook.Application();
    
    				//Create the new message by using the simplest approach.
    				Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
    
    				//Add a recipient.
    				// TODO: Change the following recipient where appropriate.
    				Outlook.Recipient oRecip = (Outlook.Recipient)oMsg.Recipients.Add("e-mail address");
    				oRecip.Resolve();
    
    				//Set the basic properties.
    				oMsg.Subject = "This is the subject of the test message";
    				oMsg.Body = "This is the text in the message.";
    
    				//Add an attachment.
    				// TODO: change file path where appropriate
    				String sSource = "C:\\setupxlg.txt";
    				String sDisplayName = "MyFirstAttachment";
    				int iPosition = (int)oMsg.Body.Length + 1;
    				int iAttachType = (int)Outlook.OlAttachmentType.olByValue;  
    				Outlook.Attachment oAttach = oMsg.Attachments.Add(sSource,iAttachType,iPosition,sDisplayName);
    
    				// If you want to, display the message.
    				// oMsg.Display(true);  //modal
    
    				//Send the message.
    				oMsg.Save();
    				oMsg.Send();
    
    				//Explicitly release objects.
    				oRecip = null;
    				oAttach = null;
    				oMsg = null;
    				oApp = null;
    			}
    
    				// Simple error handler.
    			catch (Exception e)
    			{
    				Console.WriteLine("{0} Exception caught: ", e);
    			}
    
    			//Default return value.
    			return 0;
    
    		}
    
    	}
    }
