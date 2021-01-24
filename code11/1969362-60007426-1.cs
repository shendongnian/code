    class Program
    {
        private static StoredData storedData;
        static void Main(string[] args)
        {
            storedData = LoadData();
            Console.WriteLine(storedData.NombreJoueurs);
            foreach (var item in storedData.Joueurs)
            {
                Console.WriteLine($"{item.Key}:{((pList)item.Value).Equipe}");
            }
        }
        private static StoredData LoadData()
        {
            return JsonConvert.DeserializeObject<StoredData>("{ \"76561198969362505\": {\"Equipe\": \"A\"},\"76561198454481509\": {\"Equipe\": \"b\"},\"NombreJoueurs\": 50}");
        }
    }
