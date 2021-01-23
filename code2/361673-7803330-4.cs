    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace MyIECapt
    {
        public class HtmlCapture
        {
            private WebBrowser web;
            private Timer tready;
            private Rectangle screen;
            private Size? imgsize = null;
            //an event that triggers when the html document is captured
            public delegate void HtmlCaptureEvent(object sender, Uri url);
            public event HtmlCaptureEvent HtmlImageCapture;
            string fileName = "";
            //class constructor
            public HtmlCapture(string fileName)
            {
                this.fileName = fileName;
                //initialise the webbrowser and the timer
                web = new WebBrowser();
                tready = new Timer();
                tready.Interval = 2000;
                screen = Screen.PrimaryScreen.Bounds;
                //set the webbrowser width and hight
                web.Width = 1024; //screen.Width;
                web.Height = 768; // screen.Height;
                //suppress script errors and hide scroll bars
                web.ScriptErrorsSuppressed = true;
                web.ScrollBarsEnabled = false;
                //attached events
                web.Navigating +=
                  new WebBrowserNavigatingEventHandler(web_Navigating);
                web.DocumentCompleted += new
                  WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
                tready.Tick += new EventHandler(tready_Tick);
            }
        
            public void Create(string url)
            {
                imgsize = null;
                web.Navigate(url);
            }
            public void Create(string url, Size imgsz)
            {
                this.imgsize = imgsz;
                web.Navigate(url);
            }
        
        
            void web_DocumentCompleted(object sender,
                     WebBrowserDocumentCompletedEventArgs e)
            {
                //start the timer
                tready.Start();
            }
            void web_Navigating(object sender, WebBrowserNavigatingEventArgs e)
            {
                //stop the timer   
                tready.Stop();
            }
        
            void tready_Tick(object sender, EventArgs e)
            {
                try
                {
                    //stop the timer
                    tready.Stop();
                    mshtml.IHTMLDocument2 docs2 = (mshtml.IHTMLDocument2)web.Document.DomDocument;
                    mshtml.IHTMLDocument3 docs3 = (mshtml.IHTMLDocument3)web.Document.DomDocument;
                    mshtml.IHTMLElement2 body2 = (mshtml.IHTMLElement2)docs2.body;
                    mshtml.IHTMLElement2 root2 = (mshtml.IHTMLElement2)docs3.documentElement;
                    // Determine dimensions for the image; we could add minWidth here
                    // to ensure that we get closer to the minimal width (the width
                    // computed might be a few pixels less than what we want).
                    int width = Math.Max(body2.scrollWidth, root2.scrollWidth);
                    int height = Math.Max(root2.scrollHeight, body2.scrollHeight);
                    //get the size of the document's body
                    Rectangle docRectangle = new Rectangle(0, 0, width, height);
                    web.Width = docRectangle.Width;
                    web.Height = docRectangle.Height;
                    //if the imgsize is null, the size of the image will 
                    //be the same as the size of webbrowser object
                    //otherwise  set the image size to imgsize
                    Rectangle imgRectangle;
                    if (imgsize == null) imgRectangle = docRectangle;
                    else imgRectangle = new Rectangle() { Location = new Point(0, 0), Size = imgsize.Value };
                    //create a bitmap object 
                    Bitmap bitmap = new Bitmap(imgRectangle.Width, imgRectangle.Height);
                    //get the viewobject of the WebBrowser
                    IViewObject ivo = web.Document.DomDocument as IViewObject;
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        //get the handle to the device context and draw
                        IntPtr hdc = g.GetHdc();
                        ivo.Draw(1, -1, IntPtr.Zero, IntPtr.Zero,
                                 IntPtr.Zero, hdc, ref imgRectangle,
                                 ref docRectangle, IntPtr.Zero, 0);
                        g.ReleaseHdc(hdc);
                    }
                    //invoke the HtmlImageCapture event
                    bitmap.Save(fileName);
                    bitmap.Dispose();
                }
                catch 
                {
                    //System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                if(HtmlImageCapture!=null) HtmlImageCapture(this, web.Url);
            }
        }
    }
