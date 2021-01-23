    public class Form1 : Form
    { //Beginning of the 'panels' scope
      Panels[] panels;
      public Form1()
      {
        InitializeComponent();
        panels = new Panel[10]; // initialization in constructor
      }
      private void PanelMoveTimer_Tick(object sender, EventArgs e)
      {
          if (panels[0].Location.X >= 0) // usage in method
            ..
      }
    }
