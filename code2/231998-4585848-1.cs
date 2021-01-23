	public partial class Form1 : Form
	{
		private const int Cycles = 10000000;
		public interface IMyInterface
		{
			int SameProperty { get; set; }
		}
		public class InterfacedClass : IMyInterface
		{
			public int SameProperty { get; set; }
		}
		public class SimpleClass
		{
			public int SameProperty { get; set; }
		}
		public struct InterfacedStruct : IMyInterface
		{
			public int SameProperty { get; set; }
		}
		public struct SimpleStruct
		{
			public int SameProperty { get; set; }
		}
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e) {
			var simpleClassTime = MeasureSimpleClass();
			var interfacedClassTime = MeasureInterfacedClass();
			var simpleStructTime = MeasureSimpleStruct();
			var interfacedStructTime = MeasureInterfacedStruct();
			var message = string.Format(
				"simpleClassTime = {0}\r\ninterfacedClassTime = {1}\r\nsimpleStructTime = {2}\r\ninterfacedStructTime = {3}",
				simpleClassTime,
				interfacedClassTime,
				simpleStructTime,
				interfacedStructTime
			);
			textBox.Text = message;
		}
		private static long MeasureSimpleClass() {
			var watch = Stopwatch.StartNew();
			var obj = new SimpleClass();
			for (var i = 0; i < Cycles; i++)
			{
				obj.SameProperty = i;
				var j = obj.SameProperty;
				obj.SameProperty = j;
			}
			return watch.ElapsedMilliseconds;
		}
		private static long MeasureInterfacedClass() {
			var watch = Stopwatch.StartNew();
			IMyInterface obj = new InterfacedClass();
			for (var i = 0; i < Cycles; i++) {
				obj.SameProperty = i;
				var j = obj.SameProperty;
				obj.SameProperty = j;
			}
			return watch.ElapsedMilliseconds;
		}
		private static long MeasureSimpleStruct()
		{
			var watch = Stopwatch.StartNew();
			var obj = new SimpleStruct();
			for (var i = 0; i < Cycles; i++)
			{
				obj.SameProperty = i;
				var j = obj.SameProperty;
				obj.SameProperty = j;
			}
			return watch.ElapsedMilliseconds;
		}
		private static long MeasureInterfacedStruct()
		{
			var watch = Stopwatch.StartNew();
			IMyInterface obj = new InterfacedStruct();
			for (var i = 0; i < Cycles; i++)
			{
				obj.SameProperty = i;
				var j = obj.SameProperty;
				obj.SameProperty = j;
			}
			return watch.ElapsedMilliseconds;
		}
	}
