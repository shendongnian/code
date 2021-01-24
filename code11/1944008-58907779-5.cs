	[ProtoContract(SkipConstructor = true)]
	public class Tile
	{
		[ProtoMember(1)]
		public byte Terrain { get; set; }
		[ProtoMember(2)]
		public byte Elevation { get; set; }
		[ProtoMember(3)]
		public byte Illumination { get; set; }
		[ProtoMember(4)]
		public byte Foo { get; set; }
		[ProtoMember(5)]
		public int ActorID { get; set; }
	}
	[ProtoContract(SkipConstructor = true)]
	public class Map
	{
		[ProtoMember(1)]
		public int Height { get; set; }
		[ProtoMember(2)]
		public int Width { get; set; }
		[ProtoMember(3)]
		public string Name { get; set; }
		[ProtoMember(4)]
		public Tile[] Tiles { get; set; }
	}
