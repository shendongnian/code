    Console.WriteLine((type.GetFields(
        System.Reflection.BindingFlags.NonPublic | 
        System.Reflection.BindingFlags.Static)
        .First(item => item.Name == "Title"))
        .GetValue(this));
