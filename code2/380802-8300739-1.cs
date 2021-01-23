    public partial class BoldLabel : Label
	{
		public BoldLabel()
		{
			InitializeComponent();
			base.Font = new Font(base.Font, FontStyle.Bold);
		}
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = new Font(value, FontStyle.Bold);
			}
		}
	}
