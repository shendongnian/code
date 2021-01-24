    // At the top before the class declaration
    using Newtonsoft.Json;
    using (StreamWriter writer = new StreamWriter(Convert.ToString(vars["Variable1"]) + ".txt", true))
    {
        writer.WriteLine(today); //Today Date//
        writer.WriteLine("Generated Info 1: ", JsonConvert.SerializeObject(vars["Variable1"]));
        writer.WriteLine("Generated Info 2: ", JsonConvert.SerializeObject(vars["Variable2"]));
        writer.WriteLine("Generated Info 3: ", JsonConvert.SerializeObject(vars["Variable3"]));
        writer.WriteLine("Generated Info 4: ", JsonConvert.SerializeObject(vars["Variable4"]));
    }
