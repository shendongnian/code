    var someThing = new Thing(10);
    var anotherThing = new Thingy("10");
    var newThing = new ThisThing(someThing, "Some Thing");
    var anotherNewThing = new ThisThing(anotherThing, "Some Thing");
    Console.WriteLine(newThing.ChosenThing.Number);
    Console.WriteLine(anotherNewThing.ChosenThing.Text);
