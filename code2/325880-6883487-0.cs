    foreach (Obj obj in yourBaseObjects) {
        Obj localObj = obj; // See Dans comment!!!
        Button button = new Button(); // however you create your buttons
        button.Click += {
             // do something with obj
             Console.WriteLine(localObj);
        }
    }
