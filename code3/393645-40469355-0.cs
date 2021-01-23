    using System;
    using System.Windows.Forms;
    
    namespace MessageBoxWithDetails
    {
    	/// <summary>
    	/// A dialog-style form with optional colapsable details section
    	/// </summary>
    	public partial class MessageBoxWithDetails : Form
    	{
    		private const string DetailsFormat = "Details {0}";
		public MessageBoxWithDetails(string message, string title, string details = null)
		{
			InitializeComponent();
			lblMessage.Text = message;
			this.Text = title;
			if (details != null)
			{
				btnDetails.Enabled = true;
				btnDetails.Text = DownArrow;
				tbDetails.Text = details;
			}
		}
		private string UpArrow
		{
			get
			{
				return string.Format(DetailsFormat, char.ConvertFromUtf32(0x25B4));
			}
		}
		private string DownArrow
		{
			get
			{
				return string.Format(DetailsFormat, char.ConvertFromUtf32(0x25BE));
			}
		}
		/// <summary>
		/// Meant to give the look and feel of a regular MessageBox
		/// </summary>
		public static void Show(string message, string title, string details = null)
		{
			new MessageBoxWithDetails(message, title, details).ShowDialog();
		}
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			// Change these properties now so the label is rendered so we get its real height
			var height = lblMessage.Height;
			SetMessageBoxHeight(height);
		}
		private void SetMessageBoxHeight(int heightChange)
		{
			this.Height = this.Height + heightChange;
			if (this.Height < 150)
			{
				this.Height = 150;
			}
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void btnDetails_Click(object sender, EventArgs e)
		{
			// Re-anchoring the controls so they stay in their place while the form is resized
			btnCopy.Anchor = AnchorStyles.Top;
			btnClose.Anchor = AnchorStyles.Top;
			btnDetails.Anchor = AnchorStyles.Top;
			tbDetails.Anchor = AnchorStyles.Top;
			tbDetails.Visible = !tbDetails.Visible;
			btnCopy.Visible = !btnCopy.Visible;
			
			btnDetails.Text = tbDetails.Visible ? UpArrow : DownArrow;
			SetMessageBoxHeight(tbDetails.Visible ? tbDetails.Height + 10 : -tbDetails.Height - 10);
		}
		private void btnCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(tbDetails.Text);
		}
	}
