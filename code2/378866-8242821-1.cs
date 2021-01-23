	interface ISection 
	{
		void Render(); // or String Render() if you want to return a string
	}
	class ViewSection : ISection
	{
		public String Filename { get; set; }
		public void Render()
		{
			// do stuff with Filename and/or return the content of the file
		}
	}
	class TextSection : ISection
	{
		public String Text { get; set; }
		
		public void Render()
		{
			// do stuff with Text and/or return it
		}
	}
	class DocumentSection
	{
		ISection _section;
		
		public void Render()
		{
			_section.Render();
		}
	}
