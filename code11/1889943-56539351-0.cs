	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Dapper;
	using MySql.Data.MySqlClient;
	using System.Security.Permissions;
	public class Program
	{
		public static void Main()
		{
			string _connectionString = "Server=127.0.0.1;Database=Bestellingen;Uid=root;Pwd=pwd;";
		
			var service = new BestellingenService(_connectionString);
			var result = service.GetBestellingens();
			foreach(var item in result)
			{
				Console.WriteLine(item.BestellingId);
			}
		}
	}
    //a class that represents the rows in your db table
	public class Bestellingen
	{
		public int BestellingId { get; set; }
		public int BestellingProductId { get; set; }
		public int BestellingAantal  { get; set; }
	}
    //a service that runs SQLs and returns you (lists of) your data mapping class
	public class BestellingenService
	{
		private readonly MySqlConnection _conn;
		public BestellingenService(string connStr)
		{
			_conn = new MySqlConnection(connStr);
		}
		
		public IEnumerable<Bestellingen> GetBestellingens()
		{
			var sql = "SELECT BestellingId, BestellingProductId, BestellingAantal FROM bestellingen";
			var result = this._conn.Query<Bestellingen>(sql).ToList();
			return result;
		}
		public Bestellingen GetBestellingenById(int bid)
		{
			var sql = "SELECT BestellingId, BestellingProductId, BestellingAantal FROM bestellingen WHERE id = @pBestellingId";
			var result = this._conn.Query<Bestellingen>(sql, new { pBestellingId = bid }).FirstOrDefault();
			return result;
		}
	}
	
