	using System;
	using System.Collections.Generic;
	public class structCheck
	{
		public static void Main(string[] args)
		{
			var obj = new JsonStruct();
			obj.clients.Add(new Clients());
			obj.clients[0].client_number = 100;
			Console.WriteLine(obj.clients[0].client_number);
		}
	}
	class Clients
	{
		public int client_number;
		public List<int> accounts = new List<int>();
		
	}
	class JsonStruct
	{
		public List<Clients> clients = new List<Clients>() ;
	}
