<!-- -->
    private void Button1_Click(object sender, RoutedEventArgs e)
    {
    	var button = sender as FrameworkElement;
    	Storyboard anim;
    	if ((string)button.Tag == "1") //This is just for brevity, you should of course not use the Tag to store state information, let alone number strings
    	{
    		anim = testGrid.Resources["FadeAnim1to2"] as Storyboard;
    		button.Tag = "2";
    	}
    	else
    	{
    		anim = testGrid.Resources["FadeAnim2to1"] as Storyboard;
    		button.Tag = "1";
    	}
    	anim.Begin();
    }
