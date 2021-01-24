        using Spire.Presentation;
        using System;
        using System.Linq;
        using System.Collections.Generic;
            static void Main(string[] args)
                    {
                        Presentation presentation = new Presentation();
                        //Open presentation and convert slides
                        presentation.LoadFromFile(@"C:\input.pptx");
                        //if (presentation == null) { return };
                        List<string> texts = new List<string>();
                        for (int i = 0; i < presentation.Slides.Count; i++)
                        {
                          for(int j = 0; j < presentation.Slides[i].Shapes.Count;j++)
                          {
                            //Get the shape from slide, get the text from shape and save to a new string variable.
                            IAutoShape shape = presentation.Slides[i].Shapes[j] as IAutoShape;IAutoShape shape = presentation.Slides[i].Shapes.GetEnumerator() as IAutoShape;
                    if (shape != null)
                    {
                        foreach (var s in shape.ToString())
                        {
                            var originalText = shape.TextFrame.TextRange;
                            originalText.FontHeight = 12;
                            originalText.IsItalic = TriState.True;
                            originalText.TextUnderlineType = TextUnderlineType.Single;
                            originalText.LatinFont = new TextFont("Arial");
                        }
                    }
                    Console.WriteLine(shape);
                    Console.ReadKey();
                            //save the slide to Image
                            var image = presentation.Slides[i].SaveAsImage();
                            String fileName = String.Format(@"C:\img-{0}.png", i);
                            image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        }
                      }
                    }
