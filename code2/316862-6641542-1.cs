	using System;
	using System.Collections.Generic;
	public interface IHex {
		string ToString();
	}
	public class Hex : IHex
	{
		public override string ToString() { return "Hex"; } 
	} 
	public interface IHexC : IHex {}
	public class HexC : Hex
	{
		public override string ToString() { return "HexC"; } 
	}
	public class Test{
		public static void Main()
		{
			IList<IHex> HexList = new List<IHex>();
			HexList.Add(new Hex());
			HexList.Add(new HexC());
			HexList.Add(new HexC());
			
			foreach(var o in HexList){
				Console.WriteLine(o.ToString());
			}
		}
	}
