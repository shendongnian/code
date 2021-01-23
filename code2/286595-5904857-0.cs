    public class Deck : MarshalByRefObject, IDrawable
    {
        Drawable _drawable = new Drawable(...);
        // Implement IDrawable
        void IDrawable.Foo() { _drawable.Foo(); }
        void IDrawable.Bar() { _drawable.Bar(); }
    }
