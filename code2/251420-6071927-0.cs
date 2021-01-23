	// Location in 3D space (x,y,z), w = 1 used for affine matrix transformations...
	public class Location3d : Vertex4d
	{
		// Default constructor
		public Location3d()
		{
			this.x = 0;
			this.y = 0;
			this.z = 0;
			this.w = 1;	// w = 1 used for affine matrix transformations...
		}
		// Initiated constructor(dx,dy,dz)
		public Location3d(double dx, double dy, double dz)
		{
			this.x = dx;
			this.y = dy;
			this.z = dz;
			this.w = 1; 	// w = 1 used for affine matrix transformations...
		}
	}
	// Point in 2d space(x,y) , screen coordinate system?
	public class Point2d
	{
		public int x { get; set; }				// 2D space x,y
		public int y { get; set; }
		
		// Default constructor
		public point2d()
		{
			this.x = 0;
			this.y = 0;
		}
	}
	
