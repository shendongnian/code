			using System;
			using System.Diagnostics;
			
			namespace MyPlotGraphUsingMatlabRuntimes
			{
				/// <summary>
				/// Display a graph in Matlab, from a .NET console app.
				/// </summary>
				class Program
				{
					static void Main(string[] args)
					{
						var x = new double[100];
						var y = new double[100];
						for (int i = 0; i < 100; i++) {
							x[i] = i;
							y[i] = 2 ^ i;
						}
						MyHelper.MyMatlab.MyGraph2D(x,y);
						Console.Write("[any key to exit]");
						Console.ReadKey();
					}
				}
			}
