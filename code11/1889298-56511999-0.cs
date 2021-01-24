    // A list containing the different hairstyles
    public List<BitmapImage> Hairstyles = new List<BitmapImage>();
    // Index of the current hairstyle
    public int CurrentHairstyle;
    // When right arrow is clicked
    public void ButtonRightPress(object sender, EventArgs e) {
        // Move to the next hairstyle in the list
        CurrentHairstyle += 1;
        // Loop back to the start if we're at the list's end
        if (CurrentHairstyle > Hairstyles.Count - 1) {
            CurrentHairstyle = 0;
        }
        // Make our PictureBox display the new currently selected hairstyle.
        PictureBox.Image = Hairstyles[CurrentHairstyle];
    }
    // When left arrow is clicked
    public void ButtonLeftPress(object sender, EventArgs e) {
        // Move to the previous hairstyle in the list
        CurrentHairstyle -= 1;
        // Loop forward to the end if we hit the list's beginning
        if (CurrentHairstyle < 0) {
            CurrentHairstyle = Hairstyles.Count - 1;
        }
        // Make our PictureBox display the new currently selected hairstyle.
        PictureBox.Image = Hairstyles[CurrentHairstyle];
    }
