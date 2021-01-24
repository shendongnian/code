    // create arrays which contains the controls.
    var aShips = new [] { a1f, a2f, a3f, a4f, a5f, a6f, a7f, a8f, a9f, a10f };
    var bShips = new [] { b1f, b2f, b3f, b4f, b5f, b6f, b7f, b8f, b9f, b10f };
    // notice the 0  and the < 10, because arrays are zero-indexed
    for (i = 0; i < 10; i++)
    {
        // now you can access them via the array. 
        aShips[i].BackgroundImage = Properties.Resources._1mal2_1_Rebellion;
        aShips[i].Enabled = false;
        aShips[i].Tag = "playerShip";
        bShips[i].BackgroundImage = Properties.Resources._1mal2_2_Rebellion;
        bShips[i].Enabled = false;
        bShips[i].Tag = "playerShip";
    }
