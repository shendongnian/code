    // Outer block
    {
        // Inner block
        {
            // Error due to the i variable declared in the outer block
            int i = 0;
        }
        // Scope of this variable is the whole of the outer block
        int i = 0;
    }
