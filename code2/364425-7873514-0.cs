    private bool IsFaceNoneOrPartial(Down down)
    {
       var face = down.GetFace();
    
       return face != Face.None || face != Face.Partial;
    }
    // Your code is now:
    if( down == null || IsFaceNoneOrPartial(down))
    {
      
    }
