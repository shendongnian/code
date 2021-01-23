    class CValue
    {
        public string Value { get; set; } // Notice we use properties for binding and not fields
        public Brush Quality { get; set; } // Notice we use properties for binding and not fields
        private int m_quality;
    
        public override String ToString()
        {
            return Value.ToString();
        }
    } 
    
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
            // Databind the list
            myGrid.ItemsSource = new List<CValue>
                              {
                                  new CValue
                                      {
                                          Value = "First", 
                                          Quality = new SolidColorBrush(Color.FromArgb(255, 0, 255, 255))},
                                  new CValue
                                      {
                                          Value = "Second",
                                          Quality = new SolidColorBrush(Color.FromArgb(255, 255, 0, 255))
                                      },
                                  new CValue
                                      {
                                          Value = "Third", 
                                          Quality = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255))
                                      }
                              };
        }
    }
