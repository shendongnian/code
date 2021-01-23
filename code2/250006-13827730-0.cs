		private void button1_Click(object sender, EventArgs e)
		{
			PowerPoint.Application app = new PowerPoint.Application();
			app.Visible = Office.MsoTriState.msoTrue;
			//open powerpoint file in your hard drive
			app.Presentations.Open(@"e:\my tests\hello world.pptx");
			foreach (PowerPoint.Slide slide in app.ActivePresentation.Slides)
			{
				PowerPoint.Shapes slideShapes = slide.Shapes;
				foreach (PowerPoint.Shape shape in slideShapes)
				{
					if (shape.Type == Office.MsoShapeType.msoMedia &&
						shape.MediaType == PowerPoint.PpMediaType.ppMediaTypeMovie)
					{
						//LinkFormat.SourceFullName contains the movie path 
						//get the path like this
						listBox1.Items.Add(shape.LinkFormat.SourceFullName);
						//or use System.IO.File.Copy(shape.LinkFormat.SourceFullName, SOME_DESTINATION) to export them
					}
				}
			}
		}
