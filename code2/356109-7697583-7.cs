		using System;
		using System.Collections.Generic;
		using MathWorks.MATLAB.NET.Arrays;
		
		namespace MyHelper
		{
			#region Collection of chained classes to make Matlab access easier.
			/// <summary>
			/// Collection of chained classes to make Matlab access easier.
			/// </summary>
			public static class MyMatlab
			{
				/// <summary>
				/// Returns a double in a format that can be passed into Matlab.
				/// </summary>
				/// <param name="toMatlab">Double to convert into a form we can pass into Matlab.</param>
				/// <returns>A double in Matlab format.</returns>
				public static MWNumericArray MyToMatlab(this double toMatlab)
				{
					return new MWNumericArray(toMatlab);
				}
		
				/// <summary>
				/// Converts an array that contains a single Matlab return parameter back into a .NET double.
				/// </summary>
				/// <param name="toDouble">MWArray variable, returned from Matlab code.</param>
				/// <returns>.NET double.</returns>
				public static double MyToDouble(this MWArray toDouble)
				{
					var matNumericArray = (MWNumericArray)toDouble;
					return matNumericArray.ToScalarDouble();
				}
		
				/// <summary>
				/// Converts an array that contains multiple Matlab return parameters back into a list of .NET doubles.
				/// </summary>
				/// <param name="toList">MWArray variable, returned from Matlab code.</param>
				/// <returns>List of .NET doubles.</returns>
				public static List<double> MyToDoubleList(this MWArray toList)
				{
					var matNumericArray = toList;
					var netArray = (MWNumericArray)matNumericArray.ToArray();
		
					var result = new List<double>();
					// Console.Write("{0}", netArray[1]);
					for (int i = 1; i <= netArray.NumberOfElements; i++) // Matlab arrays are 1-based, thus the odd indexing.
					{
						result.Add(netArray[i].ToScalarDouble());
					}
					return result;
				}
		
				/// <summary>
				/// Converts an array that contains multiple Matlab return parameters back into a list of .NET ints.
				/// </summary>
				/// <param name="toList">MWArray variable, returned from Matlab code.</param>
				/// <returns>List of .NET ints.</returns>
				public static List<int> MyToMWNumericArray(this MWArray toList)
				{
					var matNumericArray = toList;
					var netArray = (MWNumericArray)matNumericArray.ToArray();
		
					var result = new List<int>();
					// Console.Write("{0}", netArray[1]);
					for (int i = 1; i <= netArray.NumberOfElements; i++) // Matlab arrays are 1-based, thus the odd indexing.
					{
						result.Add(netArray[i].ToScalarInteger());
					}
					return result;
				}
		
				/// <summary>
				/// Converts an int[] array into a Matlab parameters.
				/// </summary>
				/// <param name="intArray">MWArray variable, returned from Matlab code.</param>
				/// <returns>List of .NET ints.</returns>
				public static MWNumericArray MyToMWNumericArray(this int[] intArray)
				{
					return new MWNumericArray(1, intArray.Length, intArray); // rows, columns int[] realData
				}
		
				/// <summary>
				/// Converts an double[] array into parameter for a Matlab call.
				/// </summary>
				/// <param name="arrayOfDoubles">Array of doubles.</param>
				/// <returns>MWNumericArray suitable for passing into a Matlab call.</returns>
				public static MWNumericArray MyToMWNumericArray(this double[] arrayOfDoubles)
				{
					return new MWNumericArray(1, arrayOfDoubles.Length, arrayOfDoubles); // rows, columns int[] realData
				}
		
				/// <summary>
				/// Converts an List of doubles into a parameter for a Matlab call.
				/// </summary>
				/// <param name="listOfDoubles">List of doubles.</param>
				/// <returns>MWNumericArray suitable for passing into a Matlab call.</returns>
				public static MWNumericArray MyToMWNumericArray(this List<double> listOfDoubles)
				{
					return new MWNumericArray(1, listOfDoubles.Count, listOfDoubles.ToArray()); // rows, columns int[] realData
				}
		
				/// <summary>
				/// Converts a list of some type into an array of the same type.
				/// </summary>
				/// <param name="toArray">List of some type.</param>
				/// <returns>Array of some type.</returns>
				public static T[] MyToArray<T>(this List<T> toArray)
				{
					var copy = new T[toArray.Count];
					for (int i = 0; i < toArray.Count; i++) {
						copy[i] = toArray[i];
					}
					return copy;
				}
		
				static private readonly MatlabGraph.Graph MatlabInstance = new MatlabGraph.Graph();
		
				/// <summary>
				/// Plot a 2D graph.
				/// </summary>
				/// <param name="x">Array of doubles, x axis.</param>
				/// <param name="y">Array of doubles, y axis.</param>
				/// <param name="title">Title of plot.</param>
				/// <param name="xaxis">X axis label.</param>
				/// <param name="yaxis">Y axis label.</param>
				static public void MyGraph2D(List<double> x, List<double> y, string title = "title", string xaxis = "xaxis", string yaxis = "yaxis")
				{
					MatlabInstance.Graph2D(x.MyToMWNumericArray(), y.MyToMWNumericArray(), "title", "xaxis", "yaxis");
				}
		
				/// <summary>
				/// Plot a 2D graph.
				/// </summary>
				/// <param name="x">Array of doubles, x axis.</param>
				/// <param name="y">Array of doubles, y axis.</param>
				/// <param name="title">Title of plot.</param>
				/// <param name="xaxis">X axis label.</param>
				/// <param name="yaxis">Y axis label.</param>
				static public void MyGraph2D(double[] x, double[] y, string title = "title", string xaxis = "xaxis", string yaxis = "yaxis")
				{
					MatlabInstance.Graph2D(x.MyToMWNumericArray(), y.MyToMWNumericArray(), "title", "xaxis", "yaxis");
				}
		
				/// <summary>
				/// Unit test for this class. Displays a graph using Matlab.
				/// </summary>
				static public void Unit()
				{
					{
						var x = new double[100];
						var y = new double[100];
						for (int i = 0; i < 100; i++) {
							x[i] = i;
							y[i] = Math.Sin(i);
						}
						MyGraph2D(x, y);				
					}
		
					{
						var x = new double[100];
						var y = new double[100];
						for (int i = 0; i < 100; i++) {
							x[i] = i;
							y[i] = 2 ^ i;
						}
						MyGraph2D(x, y);
					}
				}
			}
			#endregion
		}
