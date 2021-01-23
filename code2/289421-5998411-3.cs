           <ControlTemplate x:Key="ListBoxTemplate" TargetType="ListBox">
                <StackPanel>
                <ItemsPresenter  
                     Visibility="{Binding Path=IsVisible,
                    Converter={StaticResource BoolToVisibilityConverter}}">
                </ItemsPresenter>
                    <TextBlock Text="No items to select from" 
                     Visibility="{Binding Path=IsVisibleAlternative,
                     Converter={StaticResource BoolToVisibilityConverter}}"/>
                </StackPanel>
            </ControlTemplate>
            
            <Style x:Key="ListBoxStyle2" TargetType="ListBox"  >
                <Setter Property="Template" Value="{StaticResource ListBoxTemplate}">
                </Setter>
                <Setter Property="ItemsPanel">
                    <Setter.Value>
                        <ItemsPanelTemplate>
                            <StackPanel />
                        </ItemsPanelTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
