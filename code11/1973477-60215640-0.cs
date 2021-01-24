		public static void RunParaText()
		{
			string path = @"C:\Aspose Data\";
			string dataDir = path;
			string srcDir = path + "Master.pptx";
			//string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			//string file = Path.Combine(appData, srcDir);
		
			using (Presentation presentation = new Presentation(srcDir))
			{
				IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
				ILayoutSlide layoutSlide = null;
				foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
				{
					if (titleAndObjectLayoutSlide.Name == "TITRE_CONTENU")
					{
						layoutSlide = titleAndObjectLayoutSlide;
						break;
					}
				}
				var contenu = File.ReadAllText(dataDir+"contenu.txt", Encoding.UTF8);
				var slide=presentation.Slides.InsertEmptySlide(0, layoutSlide);
				IAutoShape contenuShape = (IAutoShape)slide.Shapes.SingleOrDefault(r => r.Name.Equals("contenu"));
				//IAutoShape contenuShape = (IAutoShape)layoutSlide.Shapes.SingleOrDefault(r => r.Name.Equals("contenu"));
				ITextFrame txt = ((IAutoShape)contenuShape).TextFrame;
				txt.Paragraphs.Clear();
				string[] lines = contenu.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Where(str => !String.IsNullOrEmpty(str)).ToArray();
				for (int i = 0; i < lines.Length; i++)
				{
					var portion = new Portion();
					portion.Text = lines[i];
					var paragraphe = new Paragraph();
					paragraphe.Portions.Add(portion);
					txt.Paragraphs.Add(paragraphe);
				}
				//Change font size w.r.t shape size
				contenuShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Normal;
				presentation.Save(dataDir + "AddLayoutSlides_out.pptx", SaveFormat.Pptx);
			}
		}
