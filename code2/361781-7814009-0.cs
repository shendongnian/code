    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace BarScore
    {
        public partial class MainWindow : Window
        {
            private string _BUTTON_NAME_STR = "START";
            public string BUTTON_NAME_STR
            {
               get
               {
                    return _BUTTON_NAME_STR;
               }
               set
               {
                    _BUTTON_NAME_STR = value;
               }
            }
    
            public MainWindow()
            {
                InitializeComponent();
                Start.DataContext=this;
            }
        }
    }
