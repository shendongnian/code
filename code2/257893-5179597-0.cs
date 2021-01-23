    using System;
    using System.Xml;
    using System.Xml.Xsl; 
    	
    namespace XSLTransformation
    {
    	public class Class1
    	{
    		static void Main(string[] args)
    		{
    			XslTransform myXslTransform = new XslTransform();
    	        	
    			myXslTransform.Load("reference.xsl"); 
    				
    			myXslTransform.Transform("inputfile.xml", "outputfile.xml");
    			
    	     }
    	}
    }
