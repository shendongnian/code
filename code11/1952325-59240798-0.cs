    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
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
                IList<Animal> animals = new List<Animal>() { new Animal("Tiget", "race1", "habitat1", "12"), new Animal("Cat", "race2", "habitat2", "23"), };
                Animals = CollectionViewSource.GetDefaultView(animals);
    
                InitializeComponent();
                dataGrid1.ItemsSource = Animals;
            }
    
            private void dataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                if (e.PropertyDescriptor is PropertyDescriptor prop && prop.Attributes.OfType<HiddenAttribute>().Any())
                {
                    e.Cancel = true;                
                }
            }
    
            public ICollectionView Animals { get; set; }
        }
    
    
        public class Animal
        {
            public Animal(string name, string race, string habitat, string age)
            {
                Name = name;
                Race = race;
                Habitat = habitat;
                Age = age;
            }
    
            public string Name { get; set; }
            [Hidden]
            public string Race { get; set; }
            public string Habitat { get; set; }
            public string Age { get; set; }
        }
    
        public class HiddenAttribute : Attribute
        {       
        }
    }
