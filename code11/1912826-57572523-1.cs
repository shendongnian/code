    <CarouselView ItemsSource="{Binding partners}">
        <CarouselView.ItemsLayout>
            <GridItemsLayout/>
                 </CarouselView.ItemsLayout>
                     <CarouselView.ItemTemplate>
                         <DataTemplate>
                              <Frame>
                                  <StackLayout>
                                      <Image Source="{Binding partnerLogo}"/>
                                      <Label Text="{Binding partnerText}"/>
                                      <Button Text="Read" Command="{Binding openWebsite, Source={x:Reference Name=ThisPage}}" CommandParameter="{Binding partnerLink}"/>
                                 </StackLayout>
                             </Frame>
                         </DataTemplate>
                </CarouselView.ItemTemplate>
    </CarouselView>
