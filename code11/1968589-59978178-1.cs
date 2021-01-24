<StackLayout  Grid.Row="xx" Grid.Column="xx" BindableLayout.ItemsSource="{Binding Image}" Orientation="Horizontal">
   <BindableLayout.ItemTemplate>
      <DataTemplate>
          <Image  HeightRequest="30" WidthRequest="30" Aspect="AspectFit" Source="{Binding imageSource}"/>
      </DataTemplate>
   </BindableLayout.ItemTemplate>
</StackLayout>
###in code behind
    public class MyImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public decimal Price { get; set; }
        public string MyImageSource { get; set; }
    }
Note: I noticed that you define your iamge class as **Image** , which maybe will have name conflict with Xamarin.Forms.Image . So you would better rename it like `MyImage`
###Update
<Image  Grid.Row="1" Grid.RowSpan="2" Grid.Column="2" Aspect="AspectFill" Source="{Binding demoImage}" />
public class Album
    {
        public Album()
        {
            DemoImage = Images[0].MyImageSource;
            Images.RemoveAt(0);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<MyImage> Images { get; set; }
        public string Price { get; set; }
        public string DemoImage { get; set; }
    }
