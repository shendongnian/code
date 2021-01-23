    public partial class GameWindow : Window
    {
      public GameWindow()
      {
        InitializeComponent();
        this.DataContext = new ScrabbleViewModel();
        CreateCheckBoxes();
      }
    
      void CreateCheckBoxes()
      {
        for(int y=0;y<15;y++)
        {
          for (int x = 0; x < 15; x++)
          {
            var chk = new CheckBox();
            chk.SetValue(Grid.RowProperty, y);
            chk.SetValue(Grid.ColumnProperty, x);
    
            var binding = new Binding(string.Format("GameMatrix[{0},{1}]", y, x));
            binding.Mode = BindingMode.TwoWay;
            chk.SetBinding(CheckBox.IsCheckedProperty, binding);
    
            grid.Children.Add(chk);
          }
        }
      }
    }
