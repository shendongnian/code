public Sprite()
{
   State = Default.MissingSprite;
} 
Then set other `State`s in the other constructors as appropriate.
Finally it is up to the user to check the `State` property before usage.
    var mySprite = new Sprite();
    
    // Some code which could change the State...
    switch (mySprite.State)
    {
       case Default.MissingSprite:
          ...
       break;
    
       case Default.OkSprite:
          ...
       break;
      ...
