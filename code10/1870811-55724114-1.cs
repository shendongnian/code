    <ItemsControl ItemsSource="{Binding Buttons, RelativeSource={RelativeSource AncestorType=UserControl}}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Button Command="{Binding Command}" ToolTip="{Binding TooltipText}">
                    <Image Source="{Binding Image}"/>
                </Button>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
