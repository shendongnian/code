    public class CompanyLicValues
	{
		public int Paios { get; private set; }
		public int Papc { get; private set; }
		public CompanyLicValues SumInUse(List<VwCompany> companies)
		{
			SumDynamically(companies, "InUse");
			return this; return this;
		}
		public CompanyLicValues SumSupportUsed(List<VwCompany> companies)
		{
			SumDynamically(companies, "SupportInUse");
			return this;
		}
		private void SumDynamically(IReadOnlyCollection<VwCompany> companies, string propertySuffix)
		{
			Paios = SumProperty(companies, $"{nameof(Paios)}{propertySuffix}");
			Papc = SumProperty(companies, $"{nameof(Papc)}{propertySuffix}");
		}
		private static int SumProperty(IEnumerable<VwCompany> companies, string propertyName)
		{
			var properties = typeof(VwCompany).GetProperties(); //cache properties
			var p = properties.FirstOrDefault(x => x.Name == propertyName && x.GetMethod.ReturnType == typeof(int));
			if (p is null) throw new Exception("Property Not found");
			return companies.Sum(x => (int)p.GetValue(x));
		}
	}
