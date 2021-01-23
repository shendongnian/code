	void Main()
	{
		var dimensions=GetJpegDimensions(@"path\to\my.jpg");
		Console.WriteLine(dimensions);
	}
	
	public static Dimensions GetJpegDimensions(string filePath)
	{
		using(var fs=File.OpenRead(filePath))
		{
			long blockStart;
			var buf=new byte[4];
			fs.Read(buf, 0, 4);
			if(buf.SequenceEqual(new byte[]{0xff, 0xd8, 0xff, 0xe0}))
			{
				blockStart=fs.Position;
				fs.Read(buf, 0, 2);
				ushort blockLength=(ushort)((buf[0] << 8) + buf[1]);
				fs.Read(buf, 0, 4);
				if(Encoding.ASCII.GetString(buf, 0, 4) == "JFIF" 
					&& fs.ReadByte() == 0)
				{
					blockStart += blockLength;
					while(blockStart < fs.Length)
					{
						fs.Position = blockStart;
						fs.Read(buf, 0, 4);
						blockLength = (ushort)((buf[2] << 8) + buf[3]);
						if(blockLength>=5 && buf[0]==0xff && buf[1]==0xc0)
						{
							fs.Position+=1;
							fs.Read(buf,0,4);
							var height = (buf[0]<<8) + buf[1];
							var width = (buf[2]<<8) + buf[3];
							return new Dimensions(width,height);
						}
						blockStart+=blockLength+2;
					}
				}
			}
		}
		return null;
	}
	
	public class Dimensions
	{
		private readonly int width;
		private readonly int height;
		public Dimensions(int width,int height)
		{
			this.width = width;
			this.height = height;
		}
		public int Width
		{
			get{return width;}
		}
		public int Height
		{
			get{return height;}
		}
		public override string ToString()
		{
			return string.Format("width:{0}, height:{1}", Width, Height);
		}
	}
