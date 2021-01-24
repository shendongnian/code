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
