	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Invoices")]
	public partial class Invoice : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _InvoiceId;
		
		private string _InvoiceNum;
		
		private decimal _TotalTaxDue;
