cs
class Area
{
	public static double GetArea(double radius)
	{
		return Math.PI * radius * radius;
	}
	public static double GetArea(int width, int length)
	{
		return width * length;
	}
	public static double GetArea(double radius, double height)
	{
		return Math.PI * radius * radius * height;
	}
}
Method overloading allows you to call a `GetArea` method with different parameters and return type
cs
var circleArea = Area.GetArea(1.1);
var rectrangleArea = Area.GetArea(1, 2);
var cylinderArea = Area.GetArea(1.2, 2.1);
