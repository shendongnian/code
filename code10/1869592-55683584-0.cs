    private async void ObterListaDeContas()
    {
        try
        {
            CarregamentoDeContas.IsActive = true;
            //The progress will last for two seconds
            await Task.Delay(2000);
           
        }
        finally
        {
            CarregamentoDeContas.IsActive = false;
        }
    }
