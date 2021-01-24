<controls:BulletPointItem BackgroundColor="LightBlue" Spans="{Binding Spans}">
###And in code behind or ViewModel
public static readonly BindableProperty SpansProperty =
        BindableProperty.Create(
        nameof(Spans),
        typeof(ObservableCollection<Span>),
        typeof(BulletPointItem),
        defaultValueCreator: bindable => new ObservableCollection<Span>(),
        propertyChanged: OnSpansChanged);
public ObservableCollection<Span> spans { get; set; }
spans = new ObservableCollection<Span>() {
      new Span(){Text="Span1" },
      new Span(){Text="Span2",FontAttributes=FontAttributes.Italic }
};
This will be more flexible when you want to add or remove the items from it .
##Update 
When you set the Spans purely from XAML .It will add items to the **Spans**.But the method **OnSpansChanged** will only been invoked when you set it a new value .
So you can handle the logic in method **CollectionChanged** .It will been called each time you add a new item to Spans.
public BulletPointItem()
{
  InitializeComponent();
 
  Spans.CollectionChanged += Spans_CollectionChanged;
}
// this method will been invoked 2 times if you add two span in xaml
private void Spans_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
{
   var collection = sender as ObservableCollection<Span>;
  //...  
}
