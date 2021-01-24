    <Button>
        <Button.Style>
            <Style TargetType="Button">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SomeProperty}" Value="{x:Static n:YourEnum.Value}">
                        <Setter Property="Content">
                           <Setter.Value>
                                  <!-- add the content you want to see in this case -->
                                  <Image Source="…" />
                           </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
