    public class Foo {
       public string something { get; set; }
       public string id{ get; set; }
    }
    
        private AdaptiveAction CreateCardAction(string text, Foo foo)
        {
            return new AdaptiveSubmitAction()
            {
                Title = text,
                Data = foo
            };
        }
