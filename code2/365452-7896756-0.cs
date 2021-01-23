    using System;
    using System.Xml.Xsl;
    
    class Sample {
        static public void Main(){
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("transform.xslt");
            xslt.Transform("sourcefile.xml", "result.txt");
        }
    }
