     public interface IUpdatable<U>
     {
          void Update( U newValue );
     }
     public abstract class CustomControl<T,U> : IUpdatable<U>
         where T : Control
     {
         private T  Control { get; set; }
         protected CustomControl( T control )
         {
              this.Control = control;
         }
 
         public abstract void Update( U newValue );
     }
     public class TextBoxFacade : CustomControl<TextBox,string>, IUpdatable<string>
     {
         public TextBoxFacade( TextBox textbox ) : base(textbox) { }
         public override void Update( string newValue )
         {
             this.Control.Value = newValue;
         }
     }
