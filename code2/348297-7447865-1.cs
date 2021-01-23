    CharState char1 = new CharState('A');
    CharState char2 = new CharState('X');
    System.Threading.Timer timer1 = new System.Threading.Timer(
        MoveChar, char1, 1000, 1000);
    System.Threading.Timer timer2 = new System.Threading.Timer(
        MoveChar, char2, 1200, 1200);
