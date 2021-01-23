    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using iTextSharp.text.pdf.parser;
    using iTextSharp.text.pdf;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                PdfReader reader = new PdfReader(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "nmat4-42.pdf"));
                TextWithFontExtractionStategy S = new TextWithFontExtractionStategy();
                string F = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, 1, S);
    
                //Buffers to hold various parts from the PDF
                List<string> titles = new List<string>();
                List<string> authors = new List<string>();
    
                //Array of lines of text
                string[] lines = F.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    
                //Temporary string
                string t;
    
                //Loop through each line in the array
                foreach (string line in lines)
                {
                    //See if the line looks like a "title"
                    if (line.Contains("HelveticaNeue-LightExt") && line.Contains("font-size:17.28003"))
                    {
                        //Remove the HTML tags
                        titles.Add(System.Text.RegularExpressions.Regex.Replace(line, "</?span.*?>", "").Trim());
                    }
                        //See if the line looks like an "author"
                    else if (line.Contains("HelveticaNeue-Condensed") && line.Contains("font-size:9.995972"))
                    {
                        //Remove the HTML tags and trim extra characters
                        t = System.Text.RegularExpressions.Regex.Replace(line, "</?span.*?>", "").Trim(new char[] { ' ', ',', '*' });
                        //Make sure we have a valid name, probably need some more exceptions here, too
                        if (!string.IsNullOrWhiteSpace(t) && t != "AND")
                        {
                            authors.Add(t);
                        }
                    }
                }
                //Write out the title to the console
                Console.WriteLine("Title  : {0}", string.Join(" ", titles.ToArray()));
                //Write out each author
                foreach (string author in authors)
                {
                    Console.WriteLine("Author : {0}", author);
                }
                Console.WriteLine(F);
    
                this.Close();
            }
    
            public class TextWithFontExtractionStategy : iTextSharp.text.pdf.parser.ITextExtractionStrategy
            {
                //HTML buffer
                private StringBuilder result = new StringBuilder();
    
                //Store last used properties
                private Vector lastBaseLine;
                private string lastFont;
                private float lastFontSize;
    
                //http://api.itextpdf.com/itext/com/itextpdf/text/pdf/parser/TextRenderInfo.html
                private enum TextRenderMode
                {
                    FillText = 0,
                    StrokeText = 1,
                    FillThenStrokeText = 2,
                    Invisible = 3,
                    FillTextAndAddToPathForClipping = 4,
                    StrokeTextAndAddToPathForClipping = 5,
                    FillThenStrokeTextAndAddToPathForClipping = 6,
                    AddTextToPaddForClipping = 7
                }
    
    
    
                public void RenderText(iTextSharp.text.pdf.parser.TextRenderInfo renderInfo)
                {
                    string curFont = renderInfo.GetFont().PostscriptFontName;
                    //Check if faux bold is used
                    if ((renderInfo.GetTextRenderMode() == (int)TextRenderMode.FillThenStrokeText))
                    {
                        curFont += "-Bold";
                    }
    
                    //This code assumes that if the baseline changes then we're on a newline
                    Vector curBaseline = renderInfo.GetBaseline().GetStartPoint();
                    Vector topRight = renderInfo.GetAscentLine().GetEndPoint();
                    iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(curBaseline[Vector.I1], curBaseline[Vector.I2], topRight[Vector.I1], topRight[Vector.I2]);
                    Single curFontSize = rect.Height;
    
                    //See if something has changed, either the baseline, the font or the font size
                    if ((this.lastBaseLine == null) || (curBaseline[Vector.I2] != lastBaseLine[Vector.I2]) || (curFontSize != lastFontSize) || (curFont != lastFont))
                    {
                        //if we've put down at least one span tag close it
                        if ((this.lastBaseLine != null))
                        {
                            this.result.AppendLine("</span>");
                        }
                        //If the baseline has changed then insert a line break
                        if ((this.lastBaseLine != null) && curBaseline[Vector.I2] != lastBaseLine[Vector.I2])
                        {
                            this.result.AppendLine("<br />");
                        }
                        //Create an HTML tag with appropriate styles
                        this.result.AppendFormat("<span style=\"font-family:{0};font-size:{1}\">", curFont, curFontSize);
                    }
    
                    //Append the current text
                    this.result.Append(renderInfo.GetText());
    
                    //Set currently used properties
                    this.lastBaseLine = curBaseline;
                    this.lastFontSize = curFontSize;
                    this.lastFont = curFont;
                }
    
                public string GetResultantText()
                {
                    //If we wrote anything then we'll always have a missing closing tag so close it here
                    if (result.Length > 0)
                    {
                        result.Append("</span>");
                    }
                    return result.ToString();
                }
    
                //Not needed
                public void BeginTextBlock() { }
                public void EndTextBlock() { }
                public void RenderImage(ImageRenderInfo renderInfo) { }
            }
        }
    }
