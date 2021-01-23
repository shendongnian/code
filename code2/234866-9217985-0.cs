    public partial class MyEntity
    {
        protected override void OnPropertyChanged(string property)
        {
            base.OnPropertyChanged(property);            
            // ensure that values coming from database are set as UTC
            // watch out for property name changes!
            switch (property)
            {
                case "TransferDeadlineUTC":
                    if (TransferDeadlineUTC.Kind == DateTimeKind.Unspecified)
                        TransferDeadlineUTC = DateTime.SpecifyKind(TransferDeadlineUTC, DateTimeKind.Utc);
                    break;
                case "ProcessingDeadlineUTC":
                    if (ProcessingDeadlineUTC.Kind == DateTimeKind.Unspecified)
                        ProcessingDeadlineUTC = DateTime.SpecifyKind(ProcessingDeadlineUTC, DateTimeKind.Utc);
                default:
                    break;
            }
        }
    }
