        int totalRectsInaRow = TotalWidth/ WidthOfOneRect;
        int totalRectsInaColumn = TotalHeight/ HeightOfOneRect;
      
        //Create a Grid of Width = TotalWidth and Height = Total Height;
        //Add columns equal to totalRectsInaColumn and rows equal to totalRectsInaRow in Grid
        //Set wdith of each column equal to width of one rectangle
        //set height of each row equal to height of one rectangle
        bool drawWhite = true;
        for (int i = 0; i < totalRectsInaColumn; i++)
        {
            for (int j = 0; j < totalRectsInaRow; j++)
            {
                if (drawWhite)
                { 
                    //draw white rectanlge at i column and j row
                    //basically you create a rectangle and place it in grid on particular location
                    DrawWhileRectangle(i, j);
                    drawWhite = false;
                }
                else
                {
                    //draw black rectanlge at i column and j row
                    //basically you create a rectangle and place it in grid on particular location
                    DrawBlackRectangle(i, j);
                    drawWhite = true;
                }
            }
            drawWhite = !drawWhite;
        }
