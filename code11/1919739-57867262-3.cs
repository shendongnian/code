    public class DatePickerDialogFragment: DialogFragment
    {
        private readonly Context _context;
        private DateTime _date;
        private readonly DatePickerDialog.IOnDateSetListener _listener;
        public DatePickerDialogFragment(Context context, DateTime date, DatePickerDialog.IOnDateSetListener listener)
        {
            _context = context;
            _date = date;
            _listener = listener;
        }
        public override Dialog OnCreateDialog(Bundle savedState)
        {
            var dialog = new DatePickerDialog(_context, _listener, _date.Year, _date.Month - 1, _date.Day);
            return dialog;
        }
    }
