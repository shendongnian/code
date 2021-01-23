        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
          // replacing paste by macro function Paste_cell
          CommonData.DATASHEET.Application.OnKey("^v", "Paste_cell"); 
        }
