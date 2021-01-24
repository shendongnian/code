    public void Statement()
    {
        if(curToken == Token.If)
        {
           Eat(Token.If); // Eat is convenience method that moves token pointer on
           if(curToken == Token.LParen)
           {
              Eat(Token.LParen)
              ParenExpr();
              Eat(Token.RParen);
           }
           if(curToken == Token.LBrace)
              Eat(Token.LBrace);
           Statement();
           if(curToken == Token.RBrace)
              Eat(Token.RBrace);
        }
    }
    public void ParenExpr()
    {
       // do other token checks
    }
