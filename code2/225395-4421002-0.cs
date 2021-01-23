    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    namespace WpfRadioButtonListControlTest
    {
      class MainViewModel
      {
        public ObservableCollection<Insertion> Insertions { get; set; }
        public MainViewModel()
        {
          Insertions = new ObservableCollection<Insertion>();
          Insertions.Add(new Insertion() { Text = "Item 1" });
          Insertions.Add(new Insertion() { Text = "Item 2", IsChecked=true });
          Insertions.Add(new Insertion() { Text = "Item 3" });
          Insertions.Add(new Insertion() { Text = "Item 4" });
        }
      }
      class Insertion
      {
        public string Text { get; set; }
        public bool IsChecked { get; set; }
      }
    }
