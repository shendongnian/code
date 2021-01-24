        for (int i = 0; i <= 10; i++) {
            Task task = Task.Run(() => {
                var getFromDatabase = factory().GetFromDatabase();
                if (getFromDatabase == null) {
                    Console.WriteLine("getFromDatabase == null");
                } else {
                    Console.WriteLine($"name={getFromDatabase.name} number={getFromDatabase.number }");
                }
            });
            tasks.Add(task);
        }
