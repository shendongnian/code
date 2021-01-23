    partial class CreateCharacterWindow : Window {
        private Character character;
    
        public CreateCharacterWindow ()
            : this (null) { } // designer requires parameterless constructor
    
        public CreateCharacterWindow (Character character)
        {
            this.character = character;
            InitializeComponent ();
        }
    }
    
    var spiderman = new Character ();
    var charWindow = new CreateCharacterWindow (spiderman);
