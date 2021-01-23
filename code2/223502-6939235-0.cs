    using System;
    using System.Runtime.InteropServices;
    
    namespace Overlapping
    {
    	[StructLayout(LayoutKind.Explicit)]
    	public class OverlapEvents
    	{
    		[FieldOffset(0)]
    		public Foo Source;
    
    		[FieldOffset(0)]
    		public OtherFoo Target;
    	}
    
    	public class Foo
    	{
    		public event EventHandler Clicked;
    
    		public override string ToString()
    		{
    			return "Hello Foo";
    		}
    
    		public void Click()
    		{
    			InvokeClicked(EventArgs.Empty);
    		}
    
    		private void InvokeClicked(EventArgs e)
    		{
    			var handler = Clicked;
    			if (handler != null)
    				handler(this, e);
    		}
    	}
    
    	public class OtherFoo
    	{
    		public event EventHandler Clicked;
    
    		public override string ToString()
    		{
    			return "Hello OtherFoo";
    		}
    
    		public void Click2()
    		{
    			InvokeClicked(EventArgs.Empty);
    		}
    
    		private void InvokeClicked(EventArgs e)
    		{
    			var handler = Clicked;
    			if (handler != null)
    				handler(this, e);
    		}
    
    		public void Clean()
    		{
    			Clicked = null;
    		}
    	}
    
    	class Test
    	{
    		public static void Test3()
    		{
    			var a = new Foo();
    			a.Clicked += AClicked;
    			a.Click();
    			var o = new OverlapEvents { Source = a };
    			o.Target.Click2();
    			o.Target.Clean();
    
    			o.Target.Click2();
    			a.Click();
    		}
    
    		static void AClicked(object sender, EventArgs e)
    		{
    			Console.WriteLine(sender.ToString());
    		}
    	}
    }
