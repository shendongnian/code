        <ScrollViewer>
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition />
                </Grid.RowDefinitions>
                <Image Source="{Binding SourceImage}">
                    <Image.RenderTransform>
                        <RotateTransform Angle="{Binding RotateAngle}" />
                    </Image.RenderTransform>
                </Image>
            </Grid>
        </ScrollViewer>
