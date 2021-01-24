    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.tool.xml;
    using HtmlToPdf.Models;
    using System;
    using System.IO;
    using System.Text;
    
    namespace HtmlToPdf.Console
    {
        public class HtmlToPdf
        {
            public static void Convert(HtmlToPdfModel model)
            {
                try
                {
                    if (model == null) return;
    
                    Byte[] bytes;
    
                    //Boilerplate iTextSharp setup here
                    //Create a stream that we can write to, in this case a MemoryStream
                    using (var stream = new MemoryStream())
                    {
                        //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                        using (var doc = new Document())
                        {
                            //Create a writer that's bound to our PDF abstraction and our stream
                            using (var writer = PdfWriter.GetInstance(doc, stream))
                            {
                                //Open the document for writing
                                doc.Open();
    
                                //In order to read CSS as a string we need to switch to a different constructor
                                //that takes Streams instead of TextReaders.
                                //Below we convert the strings into UTF8 byte array and wrap those in MemoryStreams
                                using (var cssStream = new MemoryStream(Encoding.UTF8.GetBytes(model.CSS)))
                                {
                                    using (var htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(model.HTML)))
                                    {
                                        var fontProvider = new XMLWorkerFontProvider();
    
                                        if (!string.IsNullOrEmpty(model.FontPath) && !string.IsNullOrEmpty(model.FontName))
                                        {
                                            fontProvider.Register(model.FontPath, model.FontName);
    
                                            //Parse the HTML with css font-family
                                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, htmlStream, cssStream, Encoding.UTF8, fontProvider);
                                        }
                                        else
                                        {
                                            //Parse the HTML without css font-family
                                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, htmlStream, cssStream);
                                        }
                                    }
                                }
    
                                doc.Close();
                            }
                        }
    
                        //After all of the PDF "stuff" above is done and closed but **before** we
                        //close the MemoryStream, grab all of the active bytes from the stream
                        bytes = stream.ToArray();
                    }
    
                    //Now we just need to do something with those bytes.
                    //Here I'm writing them to disk but if you were in ASP.Net you might Response.BinaryWrite() them.
                    //You could also write the bytes to a database in a varbinary() column (but please don't) or you
                    //could pass them to another function for further PDF processing.
    
                    // use this line on Windows version
                    //File.WriteAllBytes(model.OutputPath, bytes);
    
                    // use these lines on Mac version
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "data");
                    path = Path.Combine(path, "test.pdf");
    
                    File.WriteAllBytes(path, bytes);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
