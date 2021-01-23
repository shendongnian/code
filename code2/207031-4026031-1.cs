    public class TestObject
		{
			
			private const int BitmapWidth = 100;
			private const int BitmapHeight = 20;
			private System.Drawing.Brush _color;
			private string _name;
			private int[] _numbers;
			private int _value;
			public TestObject( string name, int value, System.Drawing.Brush color, int[] series )
			{
				_name = name;
				_numbers = series;
				_color = color;
				_value = value;
			}
			public string Name
			{
				get { return _name; }
			}
			public string Value { get { return _value.ToString(); } }
			public Image Series
			{
				get
				{
					int width = BitmapWidth / _numbers.Length - _numbers.Length;
					System.Drawing.Bitmap b = new Bitmap(BitmapWidth, BitmapHeight);
					Graphics g = Graphics.FromImage(b);
					g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
					
					int current = 0;
					for (int i = 0;i < _numbers.Length;i++)
					{
						g.FillRectangle(_color, current, BitmapHeight - (BitmapHeight / 10) * _numbers[i], width, (BitmapHeight / 10) * _numbers[i]);
						current+=width + 2;
					}
					return b;
				}
			}
		}
