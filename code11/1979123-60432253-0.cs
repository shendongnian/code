    using SomeDllNamespace.Controls.Text;
    namespace MyControls {
      public class TextArea : Textbox {
 
      }
    }
Or without using:
    namespace MyControls {
      public class TextArea : SomeDllNamespace.Controls.Text.Textbox {
 
      }
    }
