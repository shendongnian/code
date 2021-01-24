        using DDrop.BE.Models;
        using LiveCharts;
        using LiveCharts.Wpf;
        using System;
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
        using System.ComponentModel;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Media;
        
        namespace DDrop.Controls
        {
            /// <summary>
            /// Логика взаимодействия для UserControl1.xaml
            /// </summary>
            public partial class ScatterPlot : UserControl, INotifyPropertyChanged
            {
                public static readonly DependencyProperty VovaProperty =
                DependencyProperty.Register("VovaPhotos", typeof(ObservableCollection<DropPhoto>), typeof(ScatterPlot));
        
                public ObservableCollection<DropPhoto> VovaPhotos
                {
                    get { return (ObservableCollection<DropPhoto>)GetValue(VovaProperty); }
                    set { SetValue(VovaProperty, value); OnPropertyChanged(new PropertyChangedEventArgs("VovaPhotos")); }
                }
                public ScatterPlot()
                {
                    InitializeComponent();
        
                    if (DesignerProperties.GetIsInDesignMode(this))
                    {
                        return;
                    }
        
                    Loaded += SudokuUniGrid_Loaded;
                }
        
                private void SudokuUniGrid_Loaded(object sender, RoutedEventArgs e)
                {
                    ChartValues<double> values = new ChartValues<double>();
        
                    foreach (var dropPhoto in VovaPhotos)
                    {
                        values.Add(dropPhoto.Drop.RadiusInMeters);
                    }
        
                    SeriesCollection = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Title = "Series 1",
                            Values = values,
                            LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                            PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                            PointGeometrySize = 50,
                            PointForeground = Brushes.Gray
                        },
                    };
        
                    Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
                    YFormatter = value => value.ToString("C");
                    а.Update();
                    DataContext = this;
                }
                private SeriesCollection _series;
                public SeriesCollection SeriesCollection
                {
                    get
                    {
                        return _series;
                    }
                    set
                    {
                        _series = value;
                        OnPropertyChanged(new PropertyChangedEventArgs("SeriesCollection"));
                    }
                }
        
                public string[] Labels { get; set; }
                public Func<double, string> YFormatter { get; set; }
        
                public event PropertyChangedEventHandler PropertyChanged;
        
                public void OnPropertyChanged(PropertyChangedEventArgs e)
                {
                    PropertyChanged?.Invoke(this, e);
                }
            }
        }
