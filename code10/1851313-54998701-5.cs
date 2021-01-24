                List<string> cssFiles = new List<string>();
                cssFiles.Add(@"~/css/PdfDesign.css");
                //StringReader sr = new StringReader(sb.ToString());
    
                Document pdfDoc = new Document(PageSize.A4);
                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    
                using (MemoryStream memoryStream = new MemoryStream())
                {
    
    
                    //HtmlConverter.ConvertToPdf(sb.ToString(), memoryStream);
    
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    writer.CloseStream = false;
                    pdfDoc.Open();
                    HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
                    htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
                    var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
                    tagProcessors.RemoveProcessor(HTML.Tag.IMG); // remove the default processor
                  //  tagProcessors.AddProcessor(HTML.Tag.IMG, new CustomImageTagProcessor().End()); // use our new processor
    
                    var hpc = new HtmlPipelineContext(new CssAppliersImpl(new XMLWorkerFontProvider()));
                    hpc.SetAcceptUnknown(true).AutoBookmark(true).SetTagFactory(tagProcessors); // inject the tagProcessors
                    //Create a cssresolver to apply css
                    ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
                    cssFiles.ForEach(i => cssResolver.AddCssFile(System.Web.HttpContext.Current.Server.MapPath(i), true));
    
    
                    //Create and attach pipeline, without pipeline parser will not work on css
                    IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(pdfDoc, writer)));
    
    
    
                    //create XMLWork and attach a praser to it
    
    
    
                    XMLWorker worker = new XMLWorker(pipeline, true);
                    XMLParser xmlParser = new XMLParser(worker);
                    xmlParser.Parse(new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString())));
    
                    pdfDoc.Close();
                   
                    memoryStream.Position = 0;
    
    
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "inline; filename=myfile.pdf");
                    Response.BinaryWrite(memoryStream.ToArray());
                 
                    Response.Flush();
                  
                    Response.End();
            
                }
    
            }
