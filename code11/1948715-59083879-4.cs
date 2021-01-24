    public void game()
    {
        ...
        else if (userchoice == 0)
        {
            return false;
        }
        return true;
    }
    static void Main(string[] args)
    {
        Game game1 = new Game();
        game1.SetQuestion1(GetInput());
        if(!game1.game())
            return; // here you get the return-value of game and exit program if user typed zero.
        game1.DisplayAll();
    }
