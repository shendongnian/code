    using System;
    using System.Xml;
    using System.Xml.Xsl; 
    namespace XSLTransformation
    {
        /// Summary description for Class1.
        class Class1
        {
            static void Main(string[] args)
            {
                XslTransform myXslTransform; 
                myXslTransform = new XslTransform();
                myXslTransform.Load("books.xsl"); 
                myXslTransform.Transform("books.xml", "ISBNBookList.xml"); 
    
            }
        }
    }
