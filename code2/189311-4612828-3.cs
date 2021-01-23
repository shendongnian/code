		public void InvalidateBuiltinControl(string controlID)
		{
			this.ribbon.InvalidateControlMso(controlID);
		}
		public bool deleteButton_GetEnabled(IRibbonControl control)
		{
			return Globals.ThisWorkbook.CanDeleteActiveSheet();
		}
