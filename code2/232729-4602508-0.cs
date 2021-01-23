    private void myDoubleAnimation_Completed(object sender, EventArgs e)
    {
        // Animation complete, but holding, so Height will currently return
        // return the final animated value.
        double finalHeight = button.Height;
        // Remove the animation.
        button.BeginAnimation(Button.HeightProperty, null);
        // Modify the local value to be the same as the final animated value.
        button.Height = finalHeight;
    }
