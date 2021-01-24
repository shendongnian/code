	class Map
	{
		public int Height { get; set; }
		public int Width { get; set; }
		public string Name { get; set; }
		public Tile[] Tiles { get; set; }
		public void Serialize(Stream stream)
		{
			using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
			{
				writer.Write(Height);
				writer.Write(Width);
				writer.Write(Name);
				foreach (var tile in Tiles)
				{
					tile.Serialize(stream);
				}
			}
		}
		public static Map Deserialize(Stream stream)
		{
			var res = new Map();
			using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
			{
				res.Height = reader.ReadInt32();
				res.Width = reader.ReadInt32();
				res.Name = reader.ReadString();
				int tileCount = res.Height * res.Width;
				res.Tiles = new Tile[tileCount];
				for (int i = 0; i < tileCount; i++)
				{
					res.Tiles[i] = Tile.Deserialize(stream);
				}
			}
		}
	}
