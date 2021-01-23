    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace EraseMe2
    {
	class Program
	{
		static void Main(string[] args)
		{
			Test t = new Test();
			t.MyProperty = 100;
			t.MyProperty = 500;
		}
	}
	class Test
	{
		public int set(ref int prop, int val)
		{
			prop = val;
			Console.WriteLine(String.Format("{0} changed to {1}", prop.GetType().Name, val.ToString()));
			return val;
		}
		private int _myProperty;
		public int MyProperty
		{
			get { return _myProperty; }
			set
			{
				_myProperty = set(ref _myProperty, value);
			}
		}
	}
    }
