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
           if(curToken == Token.LBrace) // this will signify a block of statements
           {   
              Eat(Token.LBrace);
              while(curToken != Token.RBrace)
                 Statement();
              Eat(Token.RBrace);
           }
           else
              Statement();              
        }
    }
    public void ParenExpr()
    {
       // do other token checks
    }
