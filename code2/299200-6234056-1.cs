	public class Map : FrameworkElement
	{
		private int[][] _mapTiles;
		public Map()
		{
			_mapTiles = Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures", "*.jpg").Select(x =>
			{
				var b = new BitmapImage(new Uri(x));
				var transform = new TransformedBitmap(b, new ScaleTransform((1.0 / b.PixelWidth)*tileSize,(1.0 / b.PixelHeight)*tileSize));
				var conv = new FormatConvertedBitmap(transform, PixelFormats.Pbgra32, null, 0);
				int[] data = new int[tileSize * tileSize];
				conv.CopyPixels(data, tileSize * 4, 0);
				return data;
			}).ToArray();
			bmp = new WriteableBitmap(w * tileSize, h * tileSize, 96, 96, PixelFormats.Pbgra32, null);
			destData = new int[bmp.PixelWidth * bmp.PixelHeight];
		}
		const int w = 64, h = 64, tileSize = 8;
		public int seed = 72141;
		private int oldSeed = -1;
		private WriteableBitmap bmp;
		int[] destData;
		protected override void OnRender(DrawingContext dc)
		{
			if(seed != oldSeed)
			{
				oldSeed = seed;
				int startX = 0, endX = w;
				int startY = 0, endY = h;
				Random rnd = new Random(seed);
				for(int x = startX; x < endX; x++)
				{
					for(int y = startY; y < endY; y++)
					{
						var tile = _mapTiles[rnd.Next(_mapTiles.Length)];
						var rect = new Int32Rect(x * tileSize, y * tileSize, tileSize, tileSize);
						for(int sourceY = 0; sourceY < tileSize; sourceY++)
						{
							int destY = ((rect.Y + sourceY) * (w * tileSize)) + rect.X;
							Array.Copy(tile, sourceY * tileSize, destData, destY, tileSize);
						}
					}
				}
				bmp.WritePixels(new Int32Rect(0, 0, w * tileSize, h * tileSize), destData, w * tileSize * 4, 0);
			}
			dc.DrawImage(bmp,new Rect(0,0,w*tileSize,h*tileSize));
		}
	}
