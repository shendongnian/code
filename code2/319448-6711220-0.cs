          Driver[] predictions = new Driver[6];
          predictions[0] = new Driver(10, "Michael Schumacher");
          predictions[1] = new Driver(10, "Michael Schumacher");
          predictions[2] = new Driver(9, "Fernando Alonso");
          predictions[3] = new Driver(8, "Jensen Button");
          predictions[4] = new Driver(7, "Felipe Massa");
          predictions[5] = new Driver(6, "Giancarlo Fisichella");
          Dictionary<string, List<int>> indicies = new Dictionary<string, List<int>>();
          HashSet<string> driversWithDups = new HashSet<string>();
          for (int i=0; i<predictions.Length; i++)
          {
            Driver eachDriver = predictions[i];
            if (indicies.ContainsKey(eachDriver.Name))
            {
              indicies[eachDriver.Name].Add(i);
              driversWithDups.Add(eachDriver.Name);
            }
            else
            {
              indicies[eachDriver.Name] = new List<int>() {i};
            }
          }
