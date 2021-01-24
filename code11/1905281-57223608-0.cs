    public CodigosDeOperacao GetTheAmmountOfDisable()
    {
    	//somthing like taht
    	return Search(c=>c.Ativo).Count();
    }
