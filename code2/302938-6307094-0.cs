    public class MyCustomObject {
      public int CustomObjectIndex {get;set;}
    }
    public class ViewModel : INotifyPropertyChanged {
      public IEnumerable<MyCustomObject> Items {get { return something;} }
      // Setting this must raise PropertyChanged.
      public int SelectedIndex {get; set; }
    }
    <ComboBox ItemsSource={Binding Items}
              SelectedValue={Binding SelectedIndex, Mode=TwoWay}
              SelectedValuePath="CustomObjectIndex" />
