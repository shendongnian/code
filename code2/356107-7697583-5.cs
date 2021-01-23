		using System;
		using System.Diagnostics;
		
		namespace MyHelper
		{
			/// <summary>
			/// Display a graph from a .NET console app, using Matlab.
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
