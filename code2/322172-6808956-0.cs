	class BoxFinder {
		class Range {
			public Range(int startX, int startY, int endY) {
				StartX = startX;
				StartY = startY;
				EndY = endY;
			}
		
			public int StartX { get; private set; }
			public int StartY { get; private set; }
			public int EndY { get; private set; }
		}
		public BoxFinder(int[,] data) {
			Data = data;
			Width = data.GetLength(0);
			Height = data.GetLength(1);
			ranges = new Range[Height];
		}
	
		public int[,] Data { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }
		
		private Range[] ranges;
		public IEnumerable<Rectangle> GetBoxes() {
			for (int x = 0; x < Width; x++) {
				Range currentRange = null;
				for (int y = 0; y < Height; y++) {
					Func<Range, Rectangle> CloseRange = r => {
						currentRange = null;
						ranges[r.StartY] = null;
						return new Rectangle(
							r.StartY,
							r.StartX,
							x - r.StartX,
							r.EndY - r.StartY
						);
					};
				
					if (currentRange == null || currentRange.EndY <= y)
						currentRange = ranges[y];
						
					if (Data[x, y] == 1) {
						if (currentRange == null) {
							int startY = y;
							for (; y < Height && Data[x, y] == 1; y++) {
								if (ranges[y] != null)
									yield return CloseRange(ranges[y]);
								//If there are fuzzy edges, break; instead
							}
							ranges[startY] = new Range(x, startY, y);
							if (y == Height)
								continue;
							//Otherwise, continue to the next if in case a previous range just ended
						}
					}
					//No else; we can get here after creating a range
					if(Data[x, y] == 0) {
						if (currentRange != null)
							yield return CloseRange(currentRange);
					}
				}
			}
		}
	}
