    // Outer block
    {
        // Inner block
        {
            // This declaration is fine, and the scope is the inner block
            int i = 0;
        }
        // This is invalid, because there's no variable called "i" in scope
        i = 0;
    }
