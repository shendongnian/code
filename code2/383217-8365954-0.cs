    hiScoreName = plyrNamePos1 + plyrNamePos2 + plyrNamePos3 + plyrNamePos4 + plyrNamePos5;
    int characterSpacing = 20; //might be more or less for you
    for(int i=1; i<=5; i++){
        if(i==letterposition){
            if(gameTime.TotalGameTime.Miliseconds % 1000 < 500){
                spriteBatch.DrawString(spriteFont, hiScoreName[i-1], new Vector(350 + (i-1)*characterSpacing, 280), Color.Blue);
            }
        }else{
            spriteBatch.DrawString(spriteFont, hiScoreName[i-1], new Vector(350 + (i-1)*characterSpacing, 280), Color.Blue);
        }
    }
