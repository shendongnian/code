    public struct MyColor
    {
        public int Value;
		
		public MyColor(int a, int r, int g, int b)
		{
		    this.Value = ((a & 0xFF) << 24) | ((r & 0xFF) << 16) | ((g & 0xFF) << 8) | (b & 0xFF);
		}
		public MyColor(int r, int g, int b) :
			this(255, r, g, b)
		{
		}
        public int A
		{
			get
			{
				return (byte) (this.Value >> 24);
			}
			set
			{
				this.Value = (this.Value & ~(0xFF << 24)) | ((value & 0xFF) << 24);
			}
		}
        
		public int R
		{
			get
			{
				return (byte) (this.Value >> 16);
			}
			set
			{
				this.Value = (this.Value & ~(0xFF << 16)) | ((value & 0xFF) << 16);
			}
		}
		public int G
		{
			get
			{
				return (byte) (this.Value >> 8);
			}
			set
			{
				this.Value = (this.Value & ~(0xFF << 8)) | ((value & 0xFF) << 8);
			}
		}
		public int B
		{
			get
			{
				return (byte) (this.Value);
			}
			set
			{
				this.Value = (this.Value & ~(0xFF)) | ((value & 0xFF));
			}
		}
    }
	
