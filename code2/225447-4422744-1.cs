    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Collections.ObjectModel;
    namespace WpfTest
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
        public ObservableCollection<DataItem> Data { get; set; }
        public MainWindow()
        {
          InitializeComponent();
          // Setup the data context to refer to this object
          // depending on your design, this might all be in a ViewModel
          // of sorts
          DataContext = this;
          // Imagine this data was loaded from the database and populated into the
          // Data collection
          Data = new ObservableCollection<DataItem>();
          Data.Add(new DataItem() { Word = "Word 1", Checked = false });
          Data.Add(new DataItem() { Word = "Word 2", Checked = false });
          Data.Add(new DataItem() { Word = "Word 3", Checked = true });
          Data.Add(new DataItem() { Word = "Word 4", Checked = false });
          Data.Add(new DataItem() { Word = "Word 5", Checked = true });
        }    
      }
      public class DataItem
      {
        public string Word { get; set; }
        public bool Checked { get; set; }
      }
    }
