    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    
    namespace GroupSelect
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.Loaded +=
                    (o, e) => 
                    {
                        this.DataContext =
                            new Model(100000);
                    };
            }
        }
    
        public class Model : INotifyPropertyChanged
        {
            private bool? isAllSelected = null;
    
            public Model(int itemCount)
            {
                this.Items =
                    Enumerable.Range(1, itemCount).Select(t =>
                        new Item(this)
                    {
                        Name = "n_" + t.ToString()
                    }).ToList();
    
                this.IsAllSelected = false;
            }
    
            public List<Item> Items
            {
                get;
                private set;
            }
    
            public bool? IsAllSelected
            {
                get
                {
                    return this.isAllSelected;
                }
                set
                {
                    if (this.IsAllSelected != value)
                    {
                        this.IsBatchUpdate = true; // updating
    
                        this.isAllSelected = value;
    
                        if (this.PropertyChanged != null)
                        {
                            this.PropertyChanged(this,
                                new PropertyChangedEventArgs("IsAllSelected"));
                        }
    
                        //
                        if (this.IsAllSelected.HasValue)
                        {
                            foreach (Item i in this.Items)
                            {
                                i.IsSelected = value.Value;
                            }
                        }
    
                        this.IsBatchUpdate = false; // updating
                    }
                }
            }
    
            public bool IsBatchUpdate
            {
                get;
                private set;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        public class Item: INotifyPropertyChanged
        {
            private bool isSelected = false;
    
            public Item(Model model)
            {
                this.Model = model;
            }
    
            public Model Model
            {
                get;
                private set;
            }
    
            public string Name
            {
                get;
                set;
            }
    
            public bool IsSelected
            {
                get
                {
                    return this.isSelected;
                }
                set
                {
                    if (this.IsSelected != value)
                    {
                        this.isSelected = value;
    
                        if (this.PropertyChanged != null)
                        {
                            this.PropertyChanged(this,
                                new PropertyChangedEventArgs("IsSelected"));
                        }
    
                        if (!this.Model.IsBatchUpdate)
                        {
                            this.Model.IsAllSelected = null;
                        }
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        public class SelectorColumn : DataGridCheckBoxColumn
        {
            public SelectorColumn()
            { 
             
            }
        }
    }
