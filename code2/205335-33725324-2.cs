    interface IForm {
      void Button_OnClick(object sender, EventArgs e);
    }
    
    
    class Foo : UserControl {
      private Button btn = new Button();
    
      public Foo(IForm ctx) {
         btn.Name = "MyButton";
         btn.ButtonClick += ctx.Button_OnClick;
         Controls.Add(btn);
      }
    }
