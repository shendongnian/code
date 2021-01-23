    <Window x:Class="WPFValidation.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="Window"
            Height="300"
            Width="300">
      <Grid>
    
        <Grid.RowDefinitions>
          <RowDefinition Height="Auto" />
          <RowDefinition Height="Auto" />
          <RowDefinition />
        </Grid.RowDefinitions>
    
        <TextBox Grid.Row="0"
                 Text="{Binding FilterText, UpdateSourceTrigger=PropertyChanged}" />
        <TextBlock Grid.Row="1"
                   Text="{Binding ModelListView.Count}" />
        <ListBox Grid.Row="2"
                 ItemsSource="{Binding ModelListView}" />
    
      </Grid>
    </Window>
    
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;
    
    namespace WPFValidation
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
        public MainWindow() {
          this.DataContext = new ModelView();
          this.InitializeComponent();
        }
      }
    
      public class ModelView : INotifyPropertyChanged
      {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private ICollectionView modelListView;
    
        private ICollection<string> collection;
    
        public ModelView() {
          this.collection = new ObservableCollection<string>(new[] {"test1", "test2", "filtering"});
        }
    
        public ICollectionView ModelListView {
          get { return this.modelListView ?? this.GetModelListView(); }
        }
    
        private ICollectionView GetModelListView() {
          var collectionView = CollectionViewSource.GetDefaultView(this.collection);
          collectionView.Filter += o => o == null || string.IsNullOrEmpty(this.FilterText) || o.Equals(this.FilterText);
          return collectionView;
        }
    
        private string filterText;
    
        public string FilterText {
          get { return this.filterText; }
          set {
            if (value != this.filterText) {
              this.filterText = value;
              this.ModelListView.Refresh();
              this.RaisePropertyChange("FilterText");
            }
          }
        }
    
        private void RaisePropertyChange(string propertyName) {
          var eh = this.PropertyChanged;
          if (eh != null) {
            eh(this, new PropertyChangedEventArgs(propertyName));
          }
        }
      }
    }
