cs
public class Function {
	private readonly double[] _argv;
	private readonly Delegate _func;
	public Function(Delegate func, params double[] args) {
		_func = func;
		_argv = args;
	}
	public double Run() {
		object[] objects = new object[_argv.Length];
		int i = 0;
		foreach (var item in _argv) {
			objects[i] = item;
			i++;
		}
		object v = _func.DynamicInvoke(objects);
		return (double)v;
	}
}
And its usage lets you decide dynamically the number of arguments you wish to pass:
cs
var s = new Function((Func<double, double>)(x => Math.Sin(x)), 1); // wraps Math.Sin(1)
Console.WriteLine(s.Run()); // prints 0.8414709848078965
var p = new Function((Func<double, double, double>)((a, b) => Math.Pow(a, b)), 2, 3); // wraps Math.Pow(2, 3)
Console.WriteLine(p.Run()); // prints 8
