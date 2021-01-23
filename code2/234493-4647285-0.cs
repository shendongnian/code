        <UserControl x:Class="SilverlightApplication.MyUserControl">
            <Button Content="{Binding}">
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="Click">
                        <cmd:EventToCommand Command="{Binding ElementName=ContentGrid, Path=DataContext.TestCommand}"
                                            CommandParameter="{Binding}" />
                    </i:EventTrigger>
                </i:Interaction.Triggers>
            </Button>
        </UserControl>
