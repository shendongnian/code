    <CarouselView x:Name="MyCarousel" ItemsSource="{Binding partners}">
    <CarouselView.ItemsLayout>
        <GridItemsLayout/>
             </CarouselView.ItemsLayout>
                 <CarouselView.ItemTemplate>
                     <DataTemplate>
                          <Frame>
                              <StackLayout>
                                  <Image Source="{Binding partnerLogo}"/>
                                  <Label Text="{Binding partnerText}"/>
                                  <Button Text="Read" Command="{Binding BindingContext.openWebsite, Source={x:Reference Name=MyCarousel}}" CommandParameter="{Binding partnerLink}"/>
                             </StackLayout>
                         </Frame>
                     </DataTemplate>
            </CarouselView.ItemTemplate>
