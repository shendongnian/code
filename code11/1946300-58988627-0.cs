    protected void imgLike_Clicked(object sender, EventArgs args)
    {
                var i = (Image)sender;
                var parentGrid = i.Parent as Grid;
                var dislikeImage = parentGrid.Children[2] as Image;
                string CurrentImageSource = i.Source.ToString();
                if (CurrentImageSource.Contains("Like.png") == true)
                {
                    i.Source = "Like_Selected.png";
                    dislikeImage.Source = "Dislike.png";
                }
                else if (CurrentImageSource.Contains("Like_Selected.png") == true)
                {
                    i.Source = "Like.png";
                }
    }
