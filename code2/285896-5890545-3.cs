<!-- -->
    private void Button1_Click(object sender, RoutedEventArgs e)
    {
    	Storyboard anim;
    	if ((string)testGrid.Tag == "1") //This is just for brevity, you should of course not use the Tag to store state information, let alone number strings
    	{
    		anim = testGrid.Resources["FadeAnim1to2"] as Storyboard;
    		testGrid.Tag = "2";
    	}
    	else
    	{
    		anim = testGrid.Resources["FadeAnim2to1"] as Storyboard;
    		testGrid.Tag = "1";
    	}
    	anim.Begin();
    }
