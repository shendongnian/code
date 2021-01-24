    <ScrollView >
        <StackLayout>
            <Grid x:Name="GRID">
            </Grid>
        </StackLayout>
    </ScrollView>
And then spawning the imagebuttons with VerticalOptions = LayoutOptions.Start, like this:
new ImageButton { Source = source, Margin = new Thickness() { Top = 0, Bottom = 0, Left = 0, Right = 0 }, Padding = new Thickness() { Top = 0, Bottom = 0, Left = 0, Right = 0 }, VerticalOptions = LayoutOptions.Start };
For placing the posters at the right row/collum I used
     GRID.RowSpacing = -POSTER_HIGHT-5;
            for (int i = 0; i < imageButtons.Count; i++) {
                try {
                    Grid.SetColumn(imageButtons[i], i % PosterAtScreenWith);
                    Grid.SetRow(imageButtons[i], (int)(i / PosterAtScreenWith));   
                }
                catch (Exception) {
                    throw;
                }
            }
Which resulted in: https://vimeo.com/356240684
