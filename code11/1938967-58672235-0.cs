    [Serializable]
	public class Personee
	{
		public string Prenom { get; set; }
		public string Nom { get; set; }
		public int Age { get; set; }
		public string DateNaissance { get; set; }
		public bool IsMan { get; set; }
		public string Notes { get; set; }
		public string pathImage { get; set; }
		public string mail { get; set; }
		public string mail2 { get; set; }
		public string tel { get; set; }
		public string telFix { get; set; }
		public string site { get; set; }
		public string rue { get; set; }
		public string ville { get; set; }
		public string numero { get; set; }
		public string codePostal { get; set; }
		public string departement { get; set; }
	}
	public static string FilePath = @"contacts.dat";
	public static void RunSample()
	{
		Button_Click(null, null);
	}
