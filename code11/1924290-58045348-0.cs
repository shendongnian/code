    public class MyClass
    {
        public Reaction myReaction { get; set; }
        public MyClass()
        {
            myReaction = new EquationClass("Example");
        }
        private void ExampleListenerMethodOne(object sender, RoutedEventArgs e)
        {
            myReaction.species = Reaction.MakeAndReturnSpeciesArray();
        }
       public void ExampleListenerMethodTwo(object sender, RoutedEventArgs e)
       {
           Console.WriteLine(Reaction.species);
       }
    }
