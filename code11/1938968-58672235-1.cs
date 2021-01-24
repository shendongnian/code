	public static void Button_Click(object sender, EventArgs args)
	{
		var personee = new Personee
		{
			Prenom = "Prenom",
			Nom = "Nom",
			Age = 21,
			DateNaissance = "DateNaissance",
			IsMan = true,
			Notes = "Notes",
			pathImage = "pathImage",
			mail = "mail",
			mail2 = "mail2",
			tel = "tel",
			telFix = "telFix",
			site = "site",
			rue = "rue",
			ville = "ville",
			numero = "numero",
			codePostal = "codePostal",
			departement = "department"
		};
		SeralizePersoneeDataFile(personee);
	}
	public static void SeralizePersoneeDataFile(Personee personee)
	{
		SeralizePersoneeDataFile(new Personee[] { personee });
	}
	public static void SeralizePersoneeDataFile(IEnumerable<Personee> personees)
	{
		var personeeDataList = (File.Exists(FilePath))
			? DeseralizePersoneeDataFile()
			: new List<Personee>();
		personeeDataList.AddRange(personees);
		
		using (FileStream fichier = File.OpenWrite(FilePath))
		{
			BinaryFormatter serializer = new BinaryFormatter();
			serializer.Serialize(fichier, personeeDataList);
		}
	}
	public static List<Personee> DeseralizePersoneeDataFile()
	{
		using (FileStream fichier = File.OpenRead(FilePath))
		{
			BinaryFormatter serializer = new BinaryFormatter();
			return (serializer.Deserialize(fichier) as List<Personee>);
		}
	}
