    public bool GetFishstick(int x = 1, int y = 2, int z = 3)
    {
    ...
    }
    
    // Called as such: The other optional parameters (x,y) are supplied automatically.
    var fish = GetFishstick(z: 10);
    
    // Compare to the alternative where you have to provide them.
    var fish = GetFishstick(1,2,10);
