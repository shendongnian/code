    using System; 
    using com.lowagie.text;
    using com.lowagie.text.pdf;
    using System.IO;
    
    public class TestPDF 
    {
    	public static void Main(string[] args) 
    	{
    		Console.WriteLine("Hello World");
            
    		// step 1: creation of a document-object
    		Document document = new Document();
            
    		// step 2:
    		// we create a writer that listens to the document
    		// and directs a PDF-stream to a file
    		PdfWriter.getInstance(document, new FileStream("MyPDF.pdf", FileMode.Create));
                
    		// step 3: we open the document
    		document.open();
    
    		// step 4: we add a paragraph to the document
    		document.add(new Paragraph("Hello World"));
    
    		// step 5: we close the document
    		document.close();
    	}
    }
