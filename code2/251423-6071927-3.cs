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
	
	// Check if a normal  vertex4d of a plane is pointing away?
	// z = looking toward the screen +1 to -1	
	public bool Checkvisible(Vertex4d v)
	{
		if(v.z <= 0)
		{
			return false;		// pointing away, thus invisible
		}
		else
		{
			return true;
		}
	}
	// Check if a vertex4d is behind you, out of view(behinde de camera?)
	// z = looking toward the screen +1 to -1
	public bool CheckIsInFront(Vertex4d v)
	{
		if(v.z < 0)
		{
			return false;		// some distans from the camera
		}
		else
		{
			return true;
		}
	}
