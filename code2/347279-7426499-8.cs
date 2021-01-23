        private void pbNaprej_Click(object sender, EventArgs e)
        {
            if(MenuItemClick != null)
                MenuItemClick(this, ToolBarCommands.Naprej);             
        }
        private void pbNazaj_Click(object sender, EventArgs e)
        {
            if(MenuItemClick != null)
                MenuItemClick(this, ToolBarCommands.Nazaj);             
        }
        private void pbNovo_Click(object sender, EventArgs e)
        {
            if(MenuItemClick != null)
                MenuItemClick(this, ToolBarCommands.Novo);  
        }
