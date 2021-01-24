<CarouselView ItemSource="{Binding MyItems}">
   <CarouselView.ItemsLayout>
        <GridItemsLayout/>
            </CarouselView.ItemsLayout>
                <CarouselView.ItemTemplate>
                    <DataTemplate>
                        <Frame>
                            <Label Text="{Binding Title}"/>
                            <Label Text="{Binding Subtitle}"/>
                        </Frame>
                    </DataTemplate>
    </CarouselView.ItemTemplate>
</CarouselView>
###code behind
public class ViewModelTest : INotifyPropertyChanged
{
        
   public event PropertyChangedEventHandler PropertyChanged;
   public ObservableCollection<Model> MyItems { get; set; }
   public ViewModelTest()
   {
      MyItems = new ObservableCollection<Model>() {
         new Model(){Title="Test1" ,Subtitle="Test6" },
         new Model(){Title="Test2" ,Subtitle="Test7" },
         new Model(){Title="Test3" ,Subtitle="Test8" },
         new Model(){Title="Test4" ,Subtitle="Test9" },
         new Model(){Title="Test5" ,Subtitle="Test10" },
     };
    }
}
public class Model
{
   public string Title { get; set; }
   public string Subtitle { get; set; }
}
