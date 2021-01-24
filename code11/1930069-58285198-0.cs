`
        public CharacterMapControl()
        {
            InitializeComponent();
            var y = GetValue(FilepathProperty);
            Console.WriteLine(y);
            
            this.Loaded += (sender, args) =>
            {
                var x = GetValue(FilepathProperty);
                Console.WriteLine(x);
            };
        }
`
