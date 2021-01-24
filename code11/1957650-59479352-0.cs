    using System.Net.Http;
    using ImageMagick;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    
    namespace FunctionApp6
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static void Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log,ExecutionContext context)
            {
                log.Info("C# HTTP trigger function processed a request.");
                
                MagickNET.SetGhostscriptDirectory(context.FunctionAppDirectory);
                log.Info(context.FunctionAppDirectory);
                MagickReadSettings settings = new MagickReadSettings();
                // Settings the density to 300 dpi will create an image with a better quality
                settings.Density = new Density(300, 300);
    
                using (MagickImageCollection images = new MagickImageCollection())
                {
                    log.Info(context.FunctionAppDirectory + "\\02.pdf");
                    // Add all the pages of the pdf file to the collection
                    images.Read(context.FunctionAppDirectory+"\\02.pdf", settings);
    
                    int page = 1;
                    foreach (MagickImage image in images)
                    {
                        log.Info(context.FunctionAppDirectory + "\\outpng" + page + ".png");
                        // Write page to file that contains the page number
                        image.Write(context.FunctionAppDirectory + "\\outpng" + page + ".png");
                        // Writing to a specific format works the same as for a single image
                        //image.Format = MagickFormat.Ptif;
                        //image.Write(SampleFiles.OutputDirectory + "Snakeware.Page" + page + ".tif");
                        page++;
                    }
                }
    
                log.Info("convert finish");
            }
        }
    }
