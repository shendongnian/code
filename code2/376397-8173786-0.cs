	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using MySql.Data.MySqlClient;
	using FAXCOMLib;
	namespace MysqlConnection1
	{
		class Program
		{
			static void Main(string[] args)
			{
				string connString = "Server=localhost;Port=3306;Database=test;Uid=myuser;password=mypassword;";
				MySqlConnection conn = new MySqlConnection(connString);
				MySqlCommand command = conn.CreateCommand();
				command.CommandText = "SELECT * FROM firstcsharp";
				try
				{
					conn.Open();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				
				MySqlDataReader reader = command.ExecuteReader();
				
				if(reader.HasRows){
					while (reader.Read())
					{
						SendFax(reader["title"].ToString(),
								reader["filepath"].ToString(),
								reader["name"].ToString(),
								reader["name"].ToString());
					}
					reader.Close();
				}
			}		
			public void SendFax(string DocumentName, string FileName, string RecipientName, string FaxNumber) 
			{ 
				if (FaxNumber != "") 
				{ 
					try
					{
						FAXCOMLib.FaxServer faxServer = new FAXCOMLib.FaxServerClass(); 
						faxServer.Connect(Environment.MachineName); 
						FAXCOMLib.FaxDoc faxDoc = (FAXCOMLib.FaxDoc)faxServer.CreateDocument(FileName);  
						faxDoc.RecipientName = RecipientName;
						faxDoc.FaxNumber = FaxNumber; 
						faxDoc.DisplayName = DocumentName;
						int Response = faxDoc.Send(); 
						faxServer.Disconnect();
					}
					catch(Exception ex){ 
						MessageBox.Show(ex.Message); 
					}
				} 
			}
		}
	}
