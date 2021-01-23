    // Disclaimer: This code was written in the SO text editor.  Might not be correct.
    foreach (MyRect rect in MyRectangles)
    {
      if (rect.FadingIn)
      {
        rect.Opacity += 0.1;
        if (rect.Opacity >= 1) { rect.FadingIn = false; }
      }
      else
      {
        rect.Opacity -= 0.1;
        if (rect.Opacity <= 0 ) { rect.FadingIn = true; }
      }
    }
