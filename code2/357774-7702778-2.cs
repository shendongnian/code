xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <connectionStrings>
    <add name="csv" providerName="System.Data.OleDb" connectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source='C:\CsvFolder\';Extended Properties='text;HDR=Yes;FMT=Delimited';" />
  </connectionStrings>
</configuration>
**program.cs**:
cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Data.Common;
namespace CsvImport
{
    class Stat
    {
        public string Sport { get; set; }
        public DateTime Date { get; set; }
        public string TeamOne { get; set; }
        public string TeamTwo { get; set; }
        public int Score { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionStringSettings csv = ConfigurationManager.ConnectionStrings["csv"];
            List<Stat> stats = new List<Stat>();
            using (OleDbConnection cn = new OleDbConnection(csv.ConnectionString))
            {
                cn.Open();
                using (OleDbCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Stats.csv]";
                    cmd.CommandType = CommandType.Text;
                    using (OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        int fieldSport = reader.GetOrdinal("sport");
                        int fieldDate = reader.GetOrdinal("date");
                        int fieldTeamOne = reader.GetOrdinal("teamone");
                        int fieldTeamTwo = reader.GetOrdinal("teamtwo");
                        int fieldScore = reader.GetOrdinal("score");
                        foreach (DbDataRecord record in reader)
                        {
                            stats.Add(new Stat
                            {
                                Sport = record.GetString(fieldSport),
                                Date = record.GetDateTime(fieldDate),
                                TeamOne = record.GetString(fieldTeamOne),
                                TeamTwo = record.GetString(fieldTeamTwo),
                                Score = record.GetInt32(fieldScore)
                            });
                        }
                    }
                }
            }
            foreach (Stat stat in stats)
            {
                Console.WriteLine("Sport: {0}", stat.Sport);
            }
        }
    }
}
Here's how the csv should look
**stats.csv**:
none
sport,date,teamone,teamtwo,score
basketball,28/01/2011,Rockets,Blazers,98
baseball,22/08/2011,Yankees,Redsox,4
