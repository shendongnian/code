    // -----------------------------------------------------------------------
    // <copyright file="MainWindow.xaml.cs" company="-.-">
    // TODO: Update copyright text.
    // </copyright>
    // -----------------------------------------------------------------------
    namespace FlipImages
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.IO;
        using System.Linq;
        using System.Windows;
        using System.Windows.Media;
        using System.Windows.Media.Imaging;
        using Image = System.Windows.Controls.Image;
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            /// <summary>
            /// backing <see cref="Index"/>
            /// </summary>
            private int index = 0;
    
            /// <summary>
            /// Initializes a new instance of the MainWindow class.
            /// </summary>
            public MainWindow()
            {
                InitializeComponent();
    
                this.ImagePaths = Directory.EnumerateFiles(@"C:\temp\imgs\", "*.*", SearchOption.TopDirectoryOnly).ToList();
                
                this.mainWindow.DataContext = this;
            }
    
            /// <summary>
            /// used to notify ui about changes
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;      
    
            /// <summary>
            /// Gets or sets paths to available images
            /// </summary>
            public List<string> ImagePaths { get; set; }
    
            /// <summary>
            /// Gets path of current image
            /// </summary>
            public string CurrentPath
            {
                get
                {
                    return this.ImagePaths[this.Index];
                }
            }
    
            /// <summary>
            /// Gets or sets value currently selected with slider
            /// </summary>
            public int Index
            {
                get
                {
                    return this.index;
                }
    
                set
                {
                    this.index = value; 
                    this.OnPropertyChanged("Index");
                    this.OnPropertyChanged("CurrentPath");
                    this.OnPropertyChanged("ImageSource");
                }
            }
    
            /// <summary>
            /// Gets imagesource
            /// </summary>
            public ImageSource ImageSource
            {
                get
                {
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(this.ImagePaths[this.Index]);
                    bi.DecodePixelWidth = 200;
                    bi.EndInit();
                    
                    return bi;
                }
            }
    
            /// <summary>
            /// Raise PropertyChangedEvent
            /// </summary>
            /// <param name="propertyName">Name of property changed</param>
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler tmp = this.PropertyChanged;
    
                if (null != tmp)
                {
                    tmp(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
