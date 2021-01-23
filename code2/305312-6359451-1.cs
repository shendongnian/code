		protected void Page_Load(object sender, EventArgs e)
		{
			Button pgs = new Button();
			pgs.Command += Button1_Command;
			Controls.Add(pgs);
		}
		void Button1_Command(object sender, CommandEventArgs e)
		{
			throw new NotImplementedException();
		}
