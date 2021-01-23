    //Every instance of:
    
    string geniusMove = "";
    Genius(geniusMove, move, done);
    Console.ReadLine();
    
    //seems like it could be rewritten as:
    
    string geniusMove = "";
    Genius(geniusMove, move, done);
    done = TestMoves(geniusMove, move, done);
    Console.ReadLine();
    //and then you can remove the call to TestMoves from Genius
