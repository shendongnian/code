    public MainWindow()
    {
        InitializeComponent();
        combobox.ItemContainerGenerator.StatusChanged += new EventHandler(ItemContainerGenerator_StatusChanged);
    }
    void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
    {
        if (combobox.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
        {
            (combobox.ItemContainerGenerator.ContainerFromIndex(0) as ComboBoxItem).Focus();
        }
    }
