    using System.Windows;
    using MaterialDesignThemes.Wpf;
    
    namespace TestChipDeleting
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
            {
                BindUsers();
            }
    
            private void Chip_OnDeleteClick(object sender, RoutedEventArgs e)
            {
                var currentChip = (Chip) sender;
                UsersListBox.Items.Remove(currentChip);
            }
    
            private void BindUsers()
            {
                for (var i = 0; i < 10; i++)
                {
                    var chip = new Chip {IsDeletable = true};
                    chip.DeleteClick += Chip_OnDeleteClick;
                    chip.Content = "Username" + i;
                    chip.Icon = i;
                    UsersListBox.Items.Add(chip);
                }
            }
    
            
        }
    }
