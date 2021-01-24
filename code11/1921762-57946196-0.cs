	using System;
	using System.Drawing;
	using System.Windows.Forms;
	namespace WindowsFormsApp1
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
			}
			   
			private void Button1_Click(object sender, EventArgs e)
			{
				//comment out one of these for testing
			
				webBrowser1.Navigate(@"C:\foo\minimumWebPage.htm");
				//webBrowser1.Navigate(@"C:\foo\bigWebPage.htm");
			}
			private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
			{
				if (IsHorizontalScrollbarPresent() || IsVerticalScrollbarPresent())
				{
					webBrowser1.Size = new Size(webBrowser1.Document.Body.ScrollRectangle.Width, webBrowser1.Document.Body.ScrollRectangle.Height);
				}
			}
			public bool IsHorizontalScrollbarPresent()
			{
				return webBrowser1.Document.Body.ScrollRectangle.Width > webBrowser1.Document.Window.Size.Width;
			}
			public bool IsVerticalScrollbarPresent()
			{
				return webBrowser1.Document.Body.ScrollRectangle.Height > webBrowser1.Document.Window.Size.Height;
			}
		}
	}
