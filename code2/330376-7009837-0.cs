    public class SpesaTrasportoView
	{
		public int SPESATRASPORTOVIEW_ID { get; set; }
		public decimal PREZZO { get; set; }
		public string DESCRIZIONE { get; set; }
	}
	public class SpeseTrasportoView
	{
		public List<SpesaTrasportoView> SpeseTrasportoModello { get; set; }
	}
