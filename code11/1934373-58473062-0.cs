    <Style TargetType="{x:Type local:TestControl}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:TestControl}">
                    <Border>
                        <Grid>
                            <ContentPresenter Content="{TemplateBinding Content}" />
                            <Button x:Name="MyButton" Content="False" Height="50" Width="100" />
                            <TextBox x:Name="IsPlayingHidden" Visibility="Hidden" Text="{Binding Host.IsPlaying, RelativeSource={RelativeSource TemplatedParent}}" />
                        </Grid>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger SourceName="IsPlayingHidden" Property="Text" Value="True">
                            <Setter TargetName="MyButton" Property="Content" Value="True" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
