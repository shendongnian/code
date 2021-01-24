    foreach (var item in konacnalista)
    {
       foreach(var prop in item.GetType().GetProperties()) {
           Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(item, null));
       }
    }
    
