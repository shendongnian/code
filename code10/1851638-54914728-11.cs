            public class MySubclass : Control
            {
                public MySubclass()
                {
                    this.Click += new EventHandler( this.Clicked );
                }
                private void Clicked(Object sender, EventArgs e)
                {
                    this.BackgroundColor = Colors.Red;
                }
            }
            public class MyForm : Form
            {
                private readonly MySubclass sc;
                public MyForm()
                {
                    this.sc = new MySubclass();
                    this.Controls.Add( this.sc );
                    this.sc.Click += new EventHandler( this.SCClicked );
                }
                private void SCClicked (Object sender, EventArgs e)
                {
                    MessageBox.Show( "The control's colour is " + this.sc.BackgroundColor );
                }
            }
        As it's possible for `MyForm.SCClicked` to run before `MySubclass.Clicked`, `SCClicked` may report the old colour, not the new colour.
        By using a `virtual` method `override` this can be avoided:
            public class MySubclass : Control
            {
                protected override void OnClick(EventArgs e)
                {
                    this.BackgroundColor = Colors.Red;
                    base.OnClick( e );
                }
            }
            public class MyForm : Form { /* unchanged */ }
