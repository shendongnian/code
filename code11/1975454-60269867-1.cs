	namespace SO60269403
	{
		public class LockedOutViewModel : ANotifyPropertyChanged
		{
			private string lockedOutBy;
			private string lockedOutFor;
			private int lockedOutDate;
			public string LockedOutBy { get => lockedOutBy; set => SetProperty(ref lockedOutBy, value); }
			public string LockedOutFor { get => lockedOutFor; set => SetProperty(ref lockedOutFor, value); }
			public int LockedOutDate { get => lockedOutDate; set => SetProperty(ref lockedOutDate, value); }
		}
	}
