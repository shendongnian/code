      public ImageButton()
        {
          InitializeComponent();
        
          this.SetStyle(ControlStyles.Opaque, true);
          this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
        }
        
        protected override CreateParams CreateParams
        {
          get
          {
              CreateParams parms = base.CreateParams;
              parms.ExStyle |= 0x20;  
              return parms;
          }
        }
