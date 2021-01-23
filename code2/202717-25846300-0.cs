    `private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
         // close all before opene popup
         openedPopups.ForEach(p => p.IsOpen = false); 
         openedPopups.Clear(); // clear opened popus's collection, because they were closed
         Popup1.IsOpen = true; // open popup I need open now
         openedPopups.Add(Popup1); // remember it for future close
    }`
