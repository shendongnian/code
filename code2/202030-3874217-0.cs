	public struct VertexPositionNormalColored
	{
		public Vector3 Position;
		public Vector3 Normal;
		public Color Color; // oh look I've moved!
		public static int SizeInBytes = 7 * 4;
		public static VertexElement[] VertexElements = new VertexElement[]
		{
			new VertexElement(0,VertexElementFormat.Vector3,VertexElementUsage.Position,0),
			new VertexElement(12,VertexElementFormat.Vector3,VertexElementUsage.Normal,0),
			new VertexElement(24,VertexElementFormat.Color,VertexElementUsage.Color,0)
		};
	}
