    using System;
    using System.IO;              // System.IO and not Sysem.IO
    using System.Drawing;
    public struct MyColor
    	{
    		private byte a, r, g, b;		
    		public byte A
    		{
    			get
    			{
    				return this.a;
    			}
    		}
    		public byte R
    		{
    			get
    			{
    				return this.r;
    			}
    		}
    		public byte G
    		{
    			get
    			{
    				return this.g;
    			}
    		}
    		public byte B
    		{
    			get
    			{
    				return this.b;
    			}
    		}		
    		public MyColor SetAlpha(byte value)
    		{
    			this.a = value;
    			return this;
    		}
    		public MyColor SetRed(byte value)
    		{
    			this.r = value;
    			return this;
    		}
    		public MyColor SetGreen(byte value)
    		{
    			this.g = value;
    			return this;
    		}
    		public MyColor SetBlue(byte value)
    		{
    			this.b = value;
    			return this;
    		}
    		public int ToArgb()
    		{
    			// A Color's value is stored in a byte array blue, green, red, and alpha
    			byte[] colorArray = new byte[]{ this.B, this.G, this.R, this.A };
    			using(MemoryStream ms = new MemoryStream(colorArray))
    			{
    				using (BinaryReader br = new BinaryReader(ms))	
    				{
    					return br.ReadInt32();	
    				}
    			}
    		}
    		public override string ToString ()
    		{
    			return string.Format ("[MyColor: A={0}, R={1}, G={2}, B={3}]", A, R, G, B);
    		}
    		
    		public static MyColor FromArgb(byte alpha, byte red, byte green, byte blue)
    		{
    			return new MyColor().SetAlpha(alpha).SetRed(red).SetGreen(green).SetBlue(blue);
    		}
    		public static MyColor FromArgb(byte red, byte green, byte blue)
    		{
    			return MyColor.FromArgb(255, red, green, blue);
    		}
    		public static MyColor FromArgb(byte alpha, MyColor baseColor)
    		{
    			return MyColor.FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);
    		}
    		public static MyColor FromArgb(int argb)
    		{
    			using(MemoryStream ms = new MemoryStream())
    			{
    				using (BinaryWriter bw = new BinaryWriter(ms))
    				{					
    					bw.Write(argb);
    				}
    				byte[] buffer = ms.ToArray();	
    				// A Color's value is stored in a byte array blue, green, red, and alpha
    				byte blue = buffer[0];
    				byte green = buffer[1];
    				byte red = buffer[2];
    				byte alpha = buffer[3];				
    				return MyColor.FromArgb(alpha, red, green, blue);
    			}
    		}		
    		public static implicit operator Color(MyColor myColor)
    		{			
    			return Color.FromArgb(myColor.ToArgb());
    		}
    		public static implicit operator MyColor(Color color)
    		{
    			return MyColor.FromArgb(color.ToArgb());
    		}
    	}
