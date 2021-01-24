    private static StoredData storedData;
    private static StoredData LoadData()
    {
        return Interface.Oxide.DataFileSystem.ReadObject<StoredData>("cEvent");
    }
    		
    public class StoredData
    {
    	public int NombreJoueurs;
    	public IDictionary<string, pList> Joueurs;
    }
    
    public class pList
    {
    	public string Equipe;
    }
    		
    private void Loaded()
    {
    	storedData = LoadData();
    }
    private void CopieStats()
    {
    	Console.WriteLine(storedData.NombreJoueurs);
    	foreach (var item in storedData.Joueurs)
    	{
    		Console.WriteLine($"{item.Key}:{((pList)item.Value).Equipe}");
    	}
    }
