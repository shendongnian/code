    var items = selection.Split(',');
    foreach (var item in items)
    {
        if (int.TryParse(item, out int value))
        {
            // We're looking in the 'options' list if we have the selection the user made
            var option = options.FirstOrDefault(x => x.Item1 == value);
            if (option != null)
            {
                // If it does exist, do what you want with it. Here I'm merely printing them.
                Console.WriteLine("{0} - {1} - {2}", option.Item1, option.Item2, option.Item3);
            }
        }
    }
