    int startY;
    void Form1() : Form {
      InitializeComponent();
      startY = txtNote.Location.Y; // only set here.
    }
    // Method below fires whenever the Soft Input Panel changes
    void SIP_EnabledChanged(object sender, EventArgs e) {
      int locationY = startY;
      if (inputPanel1.Enabled) {
        locationY -= inputPanel1.Bounds.Height;
      }
      txtNote.SuspendLayout();
      // setting the Bounds was the key to getting this to work!
      txtNote.Bounds = new Rectangle(
        txtNote.Location.X,
        locationY,
        txtNote.Size.Width,
        txtNote.Size.Height
      );
      txtNote.ResumeLayout();
      txtNote.Refresh();
    }
