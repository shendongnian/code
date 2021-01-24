        using System;
    using System.Collections.Generic;
    using System.IO;
    using FactoryExample.Continent;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using CsvHelper;
    
    namespace FactoryExample
    {
        class MainApp
        {
            public static void Main()
            { try
                {
                    var client = new MongoClient("mongodb://localhost:27017");
                    var db = client.GetDatabase("local");
                    var coll = db.GetCollection<BsonDocument>("Animal");
    var reader = new StreamReader("animal.csv");
                    var csv = new CsvReader(reader);
                    csv.Configuration.HasHeaderRecord = true;
                    var records = csv.GetRecords<Animals>();
    
    
                    var dizionario = new Dictionary<string,Animal>();
                    
    
                    foreach (var animal in records)
                    {
    
                        if (dizionario.ContainsKey(animal.Continent))
                        {
                            dizionario[animal.Continent].Carnivor.Add(animal.Carnivor);
                            dizionario[animal.Continent].Herbivor.Add(animal.Herbivor);
                        }
                        else
                        {
                            var newanimal = new Animal
                            {
                                Continent = animal.Continent,
                                Carnivor = new List<string>(),
                                Herbivor = new List<string>()
                            };
    
    
                            newanimal.Carnivor.Add(animal.Carnivor);
                            newanimal.Herbivor.Add(animal.Herbivor);
                            dizionario.Add(newanimal.Continent,newanimal);
                        }
                       }
    }
    
                catch (Exception err)
                {
                    Console.WriteLine("Error!!");
                    Console.WriteLine(err.Message);
                }
    
                Console.ReadKey();
    
                //Console.Read();
    
                var continentFactory = ContinentFactory.Get(ContinentType.AMERICA);
                var carnivore = continentFactory.GetCarnivore();
                var herbivore = continentFactory.GetHerbivore();
    
                foreach (var h in herbivore)
                {
                    Console.WriteLine(h);
                }
    
                foreach (var c in carnivore)
                {
                    Console.WriteLine(c);
                }
                Console.ReadKey();
            }
    
        }
    }
