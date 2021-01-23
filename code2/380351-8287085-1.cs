	public class DrawerMixin
	{
		public void DrawRectangle() { ... }
	}
	
	public class MyClass1 : Component
	{
		public DrawerMixin Drawer { get; private set; }
		
		public MyClass1()
		{
			this.Drawer = new DrawerMixin(this);
		}
		public MyClass1(DrawerMixin drawer)
		{
			this.Drawer = drawer;
		}
		public void MyFunc()
		{
			...
			this.Drawer.DrawRectangle();
		}
	}
