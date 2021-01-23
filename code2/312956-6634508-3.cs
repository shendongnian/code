    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    using System.Xml;
    using System.Xml.Xsl;
    
    using XSLTTest.Xml;
    
    namespace XSLTTest
    {
    	public partial class frmXSLTTest : Form
    	{
    		public frmXSLTTest()
    		{
    			InitializeComponent();
    		}
    
    		private void btnTransform_Click(object sender, EventArgs e)
    		{
    			try
    			{
    				// temporary to copy from clipboard when pressing 
    				// the button instead of using the text in the textbox
    				//txtStylesheet.Text = Clipboard.GetText();
    
    				XmlDocument Stylesheet = new XmlDocument();
    				Stylesheet.InnerXml = txtStylesheet.Text;
    
    				XslCompiledTransform XCT = new XslCompiledTransform(true);
    				XCT.Load(Stylesheet);
    
    				XmlDocument InputDocument = new XmlDocument();
    				InputDocument.InnerXml = txtInputXML.Text;
    
    				XmlStringWriter OutputWriter = XmlStringWriter.Create();
    
    				XCT.Transform(InputDocument, OutputWriter);
    
    				txtOutputXML.Text = OutputWriter.ToString();
    			}
    
    			catch (Exception Ex)
    			{
    				txtOutputXML.Text = Ex.Message;
    			}
    		}
    	}
    }
