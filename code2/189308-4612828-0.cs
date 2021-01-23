        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
			this.SheetActivate += (sh) =>
				{
					this.ribbon.InvalidateBuiltinControl("SheetDelete");
				};
        }
		public bool CanDeleteActiveSheet()
		{
			if (this.ActiveSheet == null)
				return true;
            // Replace Sheet1 with your sheet's CodeName
			return ((Excel.Worksheet)this.ActiveSheet).CodeName != "Sheet1";
		}
        // Keep a local reference to the ribbon in your ThisWorkbook class
        // so you can call InvalidateControl() from it.
        Ribbon ribbon;
		protected override IRibbonExtensibility CreateRibbonExtensibilityObject()
		{
			this.ribbon = new Ribbon();
			return this.ribbon;
		}
