    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WatiN.Core;
    using WatiN.Core.Native.InternetExplorer;
    using mshtml;
    using System.Windows.Forms;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                Browser browser = new IE("http://www.google.com");
                IEElement banner = browser.Images[0].NativeElement as IEElement;
    
                IHTMLElement bannerHtmlElem = banner.AsHtmlElement;
                IEElement bodyNative = browser.Body.NativeElement as IEElement;
                mshtml.IHTMLElement2 bodyHtmlElem = (mshtml.IHTMLElement2)bodyNative.AsHtmlElement;
                mshtml.IHTMLControlRange controlRange = (mshtml.IHTMLControlRange)bodyHtmlElem.createControlRange();
    
                controlRange.add((mshtml.IHTMLControlElement)bannerHtmlElem);
                controlRange.execCommand("Copy", false, System.Reflection.Missing.Value);
                controlRange.remove(0);
                
                if (Clipboard.GetDataObject() != null)
                {
                    IDataObject data = Clipboard.GetDataObject();
                    if (data.GetDataPresent(DataFormats.Bitmap))
                    {
                        System.Drawing.Image image = (System.Drawing.Image)data.GetData(DataFormats.Bitmap, true);
    					// do something here
                    }
                }
            }
    
        }
    }
