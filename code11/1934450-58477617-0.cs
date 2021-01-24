        class Object
		{
			private Color color; 
			
			public Object(Color c)
			{        
				color = c;   
			}
		}
		var rgba = new byte[4];
		random.NextBytes(rgba);
		var obj = new Object(Color.FromArgb(rgba[0], rgba[1], rgba[2], rgba[3]));
