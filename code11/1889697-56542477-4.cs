    public bool Contar_Espaços()
    {
        gameController.contadorPontos = 0;
        for (int i = 0; i <= 13; i++)
        {
            if (espaços[i].DenteCerto)
            {
                //se os dentes e grampos são colocados no lugar certo, o contador incrementa
                gameController.contadorPontos++;
            }
        }
        if (gameController.contadorPontos == 14)
        {
            //se o jogador colocar todos os dentes e grampos nos lugares corretos, ele soma 1 ponto
            gameController.CasosResolvidos++;
            //após somar um ponto, a mandíbula é destruída para que outra seja spawnada no lugar dela
            return true;
        }
        return false;
    }
    
