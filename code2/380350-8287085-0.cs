	public interface IDrawer
	{
		...
	}
	public class DrawingMixin
	{
		public IDrawer Drawer { get; private set; }
		
		public DrawingMixin(IDrawer owner)
		{
			this.Drawer = owner;
		}
		
		public void DrawRectangle() { ... }
	}
	
	public class MyClass1 : Component, IDrawer
	{
		public DrawingMixin Drawing { get; private set; }
		
		public MyClass1()
		{
			this.Drawing = new DrawingMixin(this);
		}
		
		public void MyFunc()
		{
			...
			this.Drawing.DrawRectangle();
		}
	}
