    public async void PegaValor(bool retry)
    {
    	Activity.RunOnUiThread(async () => {
    		await PopupNavigation.PushAsync(new Paginas.PopupTentarNovamente());
    	});
    
    	Paginas.PopupTentarNovamente tentarNovamente = new Paginas.PopupTentarNovamente();
    	if (tentarNovamente.resultado)
    	{
    		retry = false;
    	}
    	else
    	{
    		retry = true;
    	}
    }
