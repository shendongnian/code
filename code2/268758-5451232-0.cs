		public static void removeWordToolbarButton(
			Microsoft.Office.Interop.Word.Application word )
		{
			var commandBar = word.CommandBars["Tools"];
			var btn = commandBar.FindControl(
				Microsoft.Office.Core.MsoControlType.msoControlButton,
				System.Reflection.Missing.Value,
				"name_of_the_button",
				System.Reflection.Missing.Value,
				System.Reflection.Missing.Value ) as Microsoft.Office.Core.CommandBarButton;
			if ( btn != null )
			{
				btn.Delete( -1 );
				Marshal.ReleaseComObject( btn );
			}
			Marshal.ReleaseComObject( commandBar );
		}
