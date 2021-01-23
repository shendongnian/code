    [ContentProcessor(DisplayName = "Processor to make sure we have vertex colours in all models")]
    public class Character_Model_Processor : ModelProcessor
    {
        public override ModelContent Process(NodeContent input, ContentProcessorContext context)
        {
			foreach(NodeContent c in input.Children)
            {
                if(c is MeshContent)
                {
                    foreach(GeometryContent g in (c as MeshContent).Geometry)
                    {
                        //Stop here and check out the VertexContent object (g.Vertices) and the Channels member of it to see how
                        //vertex data is stored in the DOM, and what you can do with it.
                        System.Diagnostics.Debugger.Launch();
                        AddVertexColorChannel(g.Vertices);
                    }
                }
            }
			
			ModelContent model = base.Process(input, context);
            return model;
        }
        private void AddVertexColorChannel(VertexContent content)
        {
            if(content.Channels.Contains(VertexChannelNames.Color(0)) == false)
            {
                List<Microsoft.Xna.Framework.Color> VertexColors = new List<Microsoft.Xna.Framework.Color>();
                for (int i = 0; i < content.VertexCount; i++)
                {
                    VertexColors.Add(Color.Purple);
                }
                content.Channels.Add(VertexChannelNames.Color(0), VertexColors);
            }
        }
	}
	
