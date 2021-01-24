    // only check this once since it isn't changed in the loop
    // do not loop at all if button wasn't pressed
    if(x)
    {
        // Do all prints in a loop
        for(int i = 0; i < 10; i++)
        {
            print(i);    // prints 0 1 2 3 4 5 6 7 8 9
        }
        
        // reset the flag so you do the printing only in the frame
        // where the button was pressed
        x = false;
    }
