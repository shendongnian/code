    using System;
    using System.IO;
    using System.Collections.Generic;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace LayerHide {
    
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    
    			PdfReader reader = new PdfReader("test.pdf");
    			PdfStamper stamp = new PdfStamper(reader, new FileStream("test2.pdf", FileMode.Create));
    			Dictionary<string, PdfLayer> layers = stamp.GetPdfLayers();
    
    			foreach(KeyValuePair<string, PdfLayer> entry in layers )
    			{
    				PdfLayer layer = (PdfLayer)entry.Value;
    				layer.On = false;
    			}
    
    			stamp.Close();
    		}
    	}
    }
