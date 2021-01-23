    class Program
      {
        static void Main(string[] args)
        {
    
          Dictionary<string, Tuple<string, string>> myHash = new Dictionary<string, Tuple<string, string>>();
    
          //Test with 10 records
    
          //Create 10 records
          Enumerable.Range(1, 10).All(a => { myHash.Add("12345" + a.ToString(), new Tuple<string, string>("user" + a.ToString(), "user" + a.ToString() + "address")); return true; });
    
          //Display 10 records
          myHash.Keys.All(a => { Console.WriteLine(string.Format("Key/Phone = {0} name = {1} address {2}", a, myHash[a].Item1, myHash[a].Item2)); return true; });
    
          Console.ReadLine();
    
        }
      }
