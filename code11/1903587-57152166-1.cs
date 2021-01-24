C#
public class SliderItem : ObservableObject
{
    public SliderItem()
    {
    }
    public SliderItem(int trans, int rot, int scale)
    {
        Translation = trans;
        Rotation = rot;
        Scale = scale;
    }
    public void UpdateValues(int newTrans, int newRot, int newScale)
    {
        Translation = newTrans;
        Rotation = newRot;
        Scale = newScale;
    }
    public void UpdateDescription(string newText)
    {
        if(!String.IsNullOrWhiteSpace(newText))
        {
            Description = newText;
            OnPropertyChanged(nameof(Description));
        }
    }
    public String Description { get; private set; }
    private int _translation = 0;
    public int Translation
    {
        get { return _translation; }
        set
        {
            if (value != _translation)
            {
                _translation = value;
                OnPropertyChanged(nameof(Translation));
            }
        }
    }
    private int _rotation = 0;
    public int Rotation
    {
        get { return _rotation; }
        set
        {
            if (value != _rotation)
            {
                _rotation = value;
                OnPropertyChanged(nameof(Rotation));
            }
        }
    }
    private int _scale = 0;
    public int Scale
    {
        get { return _scale; }
        set
        {
            if (value != _scale)
            {
                _scale = value;
                OnPropertyChanged(nameof(Scale));
            }
        }
    }
}
TripleSlider.xaml
Your XAML for TripleSlider is mostly fine; the main problem is that it's looking for a viewmodel that wasn't there before. But we also want the slider value bindings to update the bound properties when `Value` changes, not when the Slider control loses focus (which is the non-obvious default behavior). So add `UpdateSourceTrigger=PropertyChanged` to **all three Slider.Value bindings**.
XAML
    Value="{Binding Path=Translation, UpdateSourceTrigger=PropertyChanged}" 
TripleSlider.xaml.cs
This is it. This is what that class should look like. 
C#
public partial class TripleSlider : UserControl
{
    public TripleSlider()
    {
        InitializeComponent();
    }
}
MainWindow.xaml is fine. MainWindow.xaml.cs changes a bit:
C#
public partial class MainWindow : Window
{
    //  Don't use arrays. Use ObservableCollection<WhateverClass> for binding to UI controls,
    //  use List<Whatever> for anything else. 
    private ObservableCollection<SliderItem> _sliders = new ObservableCollection<SliderItem>();
    public MainWindow()
    {
        InitializeComponent();
        //  The ObservableCollection will notify the grid when you add or remove items
        //  from the collection. Set this and forget it. Everywhere else, interact with 
        //  _sliders, and let the DataGrid handle its end by itself. 
        //  Also get rid of EnableRowVirtualization="False" from the DataGrid. Let it 
        //  virtualize. 
        myDataGrid.ItemsSource = _sliders;
    }
    private void BAddControls_Click(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 49; i++)
        {
            var newSlider = new SliderItem();
            newSlider.UpdateDescription(String.Format("{0}: Unkown Value", (i+1)));
            newSlider.UpdateValues((i+1)*1337, (i+1)*1337, (i+1)*1337);
            _sliders.Add(newSlider);
        }
        bAddControls.IsEnabled = false;
    }
    private void BFetchValues_Click(object sender, RoutedEventArgs e)
    {
        if (myDataGrid.SelectedItem != null)
        {
            var selectedSlider = myDataGrid.SelectedItem as SliderItem;
            MessageBox.Show(String.Format("Translation: {0}\nRotation: {1}\nScale: {2}", selectedSlider.Translation, selectedSlider.Rotation, selectedSlider.Scale), "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
    private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        bFetchValues.IsEnabled = (myDataGrid.SelectedItem != null) ? true : false;
    }
}
