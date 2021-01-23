    partial class CreateCharacterWindow : Window {
        public CreateCharacterWindow ()
        {
            InitializeComponent ();
            createButton.Click += (sender, e) => {
                this.DialogResult = true;
                this.Close ();
            };
        }
  
        public Character CreateCharacter ()
        {
            return new Character {
                Name = nameBox.Text
            };
        }
    }
    var createWindow = new CreateCharacterWindow ();
    var doCreate = createWindow.ShowDialog ();
    if (doCreate ?? false) { // if DialogResult was specified, assume it's false 
        var character = createWindow.CreateCharacter ();
        // do whatever you like with it
    }
