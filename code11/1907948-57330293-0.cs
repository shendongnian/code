    Public Class UserControl
    {
        private Form main;
        UserControl(Form mainForm) 
        {
            initialize();
            main = mainForm;
        }
        ButtonRemoveOnClick(eventArgs e) 
        { 
            main.listTiles.Remove(""); //name or index of tile you want removed inside 
                                       //parentheses 
            main.RenderFlowLayoutTiles(); //assuming you have a method to re-render these 
                                          //tiles, otherwise, whatever code you need to 
                                          //execute to render these tiles would go here
        }
    }
