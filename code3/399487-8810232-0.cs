            <!--  Panel For Hosting UserControls  -->
            <Border Grid.Column="2">
                <ContentControl Name="userControlContentControl"
                                Content="{Binding Path=ViewToLoadProperty,
                                                  }">
                    <ContentControl.Resources>
                        <DataTemplate DataType="{x:Type ViewModelLayer:FirstViewModel}">
                            <ViewLayer:FirstView/>
                        </DataTemplate>
                        <DataTemplate DataType="{x:Type ViewModelLayer:SecondViewModel}">
                            <ViewLayer:SecondView />
                        </DataTemplate>
                                            </ContentControl.Resources>
                </ContentControl>
            </Border>
            <!--  Panel For Hosting UserControls  -->
