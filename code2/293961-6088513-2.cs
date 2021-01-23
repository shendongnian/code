    private void SetupGameBoard() {
            int counter = 0;
    
            for (int row = NUM_OF_ROWS-1; row > -1; row--) {
                if(row % 2 == 0){
                   for (int column = NUM_OF_COLUMNS; column > -1; column--) {
                    SquareControl squareControl = new SquareControl
                        (hareAndTortoiseGame.Board.Squares[counter], hareAndTortoiseGame.Players);
                    if ((row == 6 && column == 0) || (row == 0 && column == 5)){
                        squareControl.BackColor = Color.BurlyWood;
                    }
                    GameTableLayout.Controls.Add(squareControl, column, row);
                    counter++;
                   }
                }
                else{
                   for (int column = 0; column < NUM_OF_COLUMNS; column++) {
                    SquareControl squareControl = new SquareControl
                        (hareAndTortoiseGame.Board.Squares[counter], hareAndTortoiseGame.Players);
                    if ((row == 6 && column == 0) || (row == 0 && column == 5)){
                        squareControl.BackColor = Color.BurlyWood;
                    }
                    GameTableLayout.Controls.Add(squareControl, column, row);
                    counter++;
                   }
                }
            }
