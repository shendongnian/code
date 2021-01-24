<controls:BulletPointItem BackgroundColor="LightBlue" Spans="{Binding Spans}">
###And in code behind or ViewModel
public ObservableCollection<Span> spans { get; set; }
spans = new ObservableCollection<Span>() {
      new Span(){Text="Span1" },
      new Span(){Text="Span2",FontAttributes=FontAttributes.Italic }
};
This will be more flexible when you want to add or remove the items from it .
