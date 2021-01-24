    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;
    
    namespace CustomizeDataGrid
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Animals = CollectionViewSource.GetDefaultView(new List<Animal>() { new Animal("Tiger", "Habitat1", "12"), new Animal("Cat", "Habitat2", "23"), });
                UserControl1.DataGrid1.ItemsSource = Animals;
            }
    
            public ICollectionView Animals { get; set; }
        }
    
        public class Animal
        {
            public Animal(string name, string habitat, string age)
            {
                Name = name;
                Habitat = habitat;
                Age = age;
            }
    
            public string Name { get; set; }
            public string Habitat { get; set; }
            public string Age { get; set; }
        }   
    }
