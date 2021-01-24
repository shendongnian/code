    <HyperlinkButton
                x:Name="AlbumTextButton"
                Grid.Row="0"
                Grid.Column="2"
                Margin="0,0,10,0"
                VerticalAlignment="Center"
                Click="Album_Click"
                DataContext="{Binding Album}"
                Foreground="{Binding IsPlaying, Converter={StaticResource PlaylistRowColorConverter}, ConverterParameter=Gray, Mode=OneWay}"
                Style="{StaticResource TextButtonStyle}"
                Visibility="{x:Bind ShowAlbumText, Converter={StaticResource VisibilityConverter}, Mode=OneWay}" />
