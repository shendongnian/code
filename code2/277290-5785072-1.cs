    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Loaded += new RoutedEventHandler(MainWindow_Loaded);
		}
		const int size = 1000, elementSize = 20;
		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			var c = new[] { Brushes.PowderBlue, Brushes.DodgerBlue, Brushes.MediumBlue};
			elements = c.Select((x, i) => new Border
			{
				Background = x,
				Width = elementSize,
				Height = elementSize,
				BorderBrush = Brushes.Black,
				BorderThickness = new Thickness(1),
				Child = new TextBlock
				{
					Text = i.ToString(),
					HorizontalAlignment = HorizontalAlignment.Center
				}
			}).ToArray();
			
			grid = new int[size, size];
			for(int y = 0; y < size; y++)
			{
				for(int x = 0; x < size; x++)
				{
					grid[x, y] = rnd.Next(elements.Length);
				}
			}
			var layers = elements.Select(x => new Rectangle()).ToArray();
			masks = new WriteableBitmap[elements.Length];
			maskDatas = new int[elements.Length][];
			for(int i = 0; i < layers.Length; i++)
			{
				layers[i].Width = size * elementSize;
				layers[i].Height = size * elementSize;
				layers[i].Fill = new VisualBrush(elements[i])
				{
					Stretch = Stretch.None,
					TileMode = TileMode.Tile,
					Viewport = new Rect(0,0,elementSize,elementSize),
					ViewportUnits = BrushMappingMode.Absolute
				};
				root.Children.Add(layers[i]);
				if(i > 0) //Bottom layer doesn't need a mask
				{
					masks[i] = new WriteableBitmap(size, size, 96, 96, PixelFormats.Pbgra32, null);
					maskDatas[i] = new int[size * size];
					layers[i].OpacityMask = new ImageBrush(masks[i]);
					RenderOptions.SetBitmapScalingMode(layers[i], BitmapScalingMode.NearestNeighbor);
				}
			}
			root.Width = root.Height = size * elementSize;
			UpdateGrid();
		}
		Random rnd = new Random();
		private int[,] grid;
		private Visual[] elements;
		private WriteableBitmap[] masks;
		private int[][] maskDatas;
		private void UpdateGrid()
		{
			const int black = -16777216, transparent = 0;
			for(int y = 0; y < size; y++)
			{
				for(int x = 0; x < size; x++)
				{
					grid[x, y] = (grid[x, y] + 1) % elements.Length;
					for(int i = 1; i < maskDatas.Length; i++)
					{
						maskDatas[i][y * size + x] = grid[x, y] == i ? black : transparent;
					}
				}
			}
			for(int i = 1; i < masks.Length; i++)
			{
				masks[i].WritePixels(new Int32Rect(0, 0, size, size), maskDatas[i], masks[i].BackBufferStride, 0);
			}
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var s = Stopwatch.StartNew();
			UpdateGrid();
			Console.WriteLine(s.ElapsedMilliseconds + "ms");
		}
		private void root_MouseDown(object sender, MouseButtonEventArgs e)
		{
			var p = e.GetPosition(root);
			int x = (int)p.X / elementSize;
			int y = (int)p.Y / elementSize;
			MessageBox.Show(string.Format("You clicked X:{0},Y:{1} Value:{2}", x, y, grid[x, y]));
		}
	}
	
