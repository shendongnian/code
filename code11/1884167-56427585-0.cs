`csharp
    using System;
    using System.IO;
    using System.Threading;
    using System.Web.Mvc;
    namespace stackoverflow_56307594.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult A()
            {
                readFile();
                return View();
            }
            public ActionResult B()
            {
                writeFile();
                return View();
            }
            private static object writeLock = new Object();
            private void readFile()
            {
                while (!Monitor.TryEnter(writeLock, 5000)) ; //wait 5000 ms for the writeLock (serializing access)
                using (var stream = new FileStream("filePath", FileMode.Open, FileAccess.Read, FileShare.Read))
                using (var reader = new StreamReader(stream))
                {
                    // active read
                    // xDocument = XDocument.Parse(streamReader.ReadToEnd());
                }
            }
            private void writeFile()
            {
                lock (writeLock)
                {
                    FileStream stream = null;
                    while (stream == null) //wait for the active read
                    {
                        try
                        {
                            stream = new FileStream("filePath", FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                        }
                        catch (IOException)
                        {
                        // will fail if active read becase FileShare.None   while (stream == null) will  wait
                    }
                }
                    Request.Files[0].InputStream.CopyTo(stream);
                }// unlock
            }
       
        }
    }
`
