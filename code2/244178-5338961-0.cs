        public MainPage()
        {
            InitializeComponent();
            // load C1SpellChecker dictionary from embedded resource
            var asm = this.GetType().Assembly;
            foreach (var res in asm.GetManifestResourceNames())
            {
                if (res.EndsWith(".dct"))
                {
                    using (var s = asm.GetManifestResourceStream(res))
                    {
                        sc.MainDictionary.Load(s);
                        break;
                    }
                }
            }
        }
