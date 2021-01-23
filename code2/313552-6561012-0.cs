    public class PageEvents : PdfPageEventHelper  
       {        
           public override void OnStartPage(PdfWriter writer, Document document)  
           {  
               base.OnStartPage(writer, document);    
               document.Add(...header...);  
           }  
       }
  
  
