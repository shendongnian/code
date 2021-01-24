    <Grid>
      <AutoscrollListBox Name="Items" >
        <AutoscrollListBox.ItemTemplate>
          <DataTemplate>
            <ContentControl x:Name="ContentPresenter" />
            <DataTemplate.Triggers>
              <DataTrigger Binding="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=ListBoxItem}, Path=IsSelected}" 
                           Value="False">
                <Setter TargetName="ContentPresenter" 
                        Property="Content">
                  <Setter.Value>
                    <AutoscaleTextBlock Text="{Binding Title}"                           
                                        Style="{StaticResource AOTbMain_MARQUEE}" />
                   </Setter.Value>
                 </Setter>
              </DataTrigger>
              <DataTrigger Binding="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=ListBoxItem}, Path=IsSelected}" 
                           Value="True">
                <Setter TargetName="ContentPresenter" 
                        Property="Content">
                  <Setter.Value>
                    <MarqueeTextBlock Text="{Binding Title}"                           
                                      Style="{StaticResource AOTbMain_MARQUEE}"/>
                   </Setter.Value>
                 </Setter>
              </DataTrigger>
            </DataTemplate.Triggers>
          </DataTemplate>
        </AutoscrollListBox.ItemTemplate>
      </AutoscrollListBox>
    </Grid>
