    public partial class Window1 : Window
    {
        private StackPanel m_stackPanel;
        private Expander m_expander;
        private FrameworkElement m_expanderAddIn;
        public Window1()
        {
            InitializeComponent();
            m_stackPanel = new StackPanel { Orientation = Orientation.Vertical };
            m_stackPanel.Background = Brushes.Red;
            m_expander = new Expander
                             {
                                 ExpandDirection = ExpandDirection.Right,
                                 Background=Brushes.Blue,
                                 IsExpanded=true,
                             };
            m_expander.Expanded += CheckStuff;
            m_expander.Collapsed += CheckStuff;
            Rectangle r = new Rectangle {Fill = Brushes.LightGray, Height = 300, Width = 300};
            m_expander.Content = r;
            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(m_expander);
            m_expanderAddIn = FrameworkElementAdapters.ContractToViewAdapter(FrameworkElementAdapters.ViewToContractAdapter(stackPanel));
            Binding binding = new Binding("ActualHeight");
            binding.Source = m_expander;
            m_expanderAddIn.SetBinding(FrameworkElement.HeightProperty, binding);
            m_stackPanel.Children.Add(m_expanderAddIn);
            Content = m_stackPanel;
        }
        private void CheckStuff(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Expander: " + m_expander.DesiredSize);
            Debug.WriteLine("Add in: " + m_expanderAddIn.DesiredSize);
            Debug.WriteLine("Stack Panel: " + m_stackPanel.DesiredSize);
        }
    }
