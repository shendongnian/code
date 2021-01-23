    public struct Point 
    {
       public int x, y;
       public Point(int p1, int p2) 
       {
           x = p1;
           y = p2;    
       }
    }
    void Main()
    {
        //create a point
        var point1 = new Point(10, 10); 
	
        //assign point2 to point, point2
        var point2 = point1; 
	
        //change the value of point2.x
        point2.x = 20; 
	
        //you will notice that point1.x does not change
        //this is because point2 is set by value, not reference.
        Console.WriteLine(point1.x);
        Console.WriteLine(point2.x);
	
    }
