    private static readonly object lockObject = new object();
    public DadoMySql PegaPrimeiroFila(int identificacao)
    {
        DadoMySql dadoMySql = null;
        lock (lockObject)
        {
            dadoMySql = PegaPrimeiroFila_Processa();
        }
        return dadoMySql;
    }
