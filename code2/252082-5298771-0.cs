    using Outlook = Microsoft.Office.Interop.Outlook;
    namespace Foo
    {
        public class Bar
        {
            public void Quux()
            {
                try
                {
                    // try to instantiate outlook COM object.
                    Outlook.Application outlookApp = new Outlook.Application();
                    // if it works, fine. Proceed
                    ...
                }
                // If we catch a COMException, assume no office installed. Deal accordingly.
                catch (System.Runtime.InteropServices.COMException)
                {
                    ...
                }
            }
        }
    }
