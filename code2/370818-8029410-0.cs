    using System;
    using System.Linq;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Drawing;
     
     
    namespace OpenXmlGetPowerpointTextInfo
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (PresentationDocument myPres = PresentationDocument.Open(@"test.pptx", true))
                {
                    PresentationPart presPart = myPres.PresentationPart;
                    //SlidePart slide = presPart.GetPartsOfType<SlidePart>().FirstOrDefault();
                    SlidePart[] slidePartList = presPart.SlideParts.ToArray();
                    foreach (SlidePart part in slidePartList)
                    {
                        RunProperties[] runProList = part.Slide.Descendants<RunProperties>().ToArray();
                        foreach (RunProperties r in runProList)
                       {
                           Console.WriteLine(r.FontSize.Value);
                       }
                    }
                }
            }
        }
    }
