     using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Web.Mail;
        using System.Runtime.InteropServices;
        using System.EnterpriseServices;
    
    
        namespace SSDSCommunicator
        {
    
            [InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("DB38A91C-9EB6-4472-9A49-40722431E096")]
            public interface IEmailClass
            {           
                bool Send(string szFrom, string szTo, string szSubject, string szMessage, string szSMTPServer, ref object szError, string szAttachments = "", string szReplyTo = "", string szCC = "", string szBCC = "", bool bHTMLBody = false);
            }
    
            [ClassInterface(ClassInterfaceType.None), Guid("A00C16DA-1791-4A3A-8D16-4765A9FAD060"), ProgId("SSDSCommunicator.EmailClass")]
            public class EmailClass : ServicedComponent, IEmailClass
            {
                private string path = null;           
    
                public bool Send(string szFrom, string szTo, string szSubject, string szMessage, string szSMTPServer, ref object szError, string szAttachments = "", string szReplyTo = "", string szCC = "", string szBCC = "",    bool bHTMLBody = false)
     {...
    }
    
            }
        }
