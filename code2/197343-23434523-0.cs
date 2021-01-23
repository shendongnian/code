    class customPrintPreviewDialog : PrintPreviewDialog
    {
       public customPrintPreviewDialog() //default constructor
        {
            // over ride the print button default enabled property
           ((ToolStripButton)((ToolStrip)this.Controls[1]).Items[0]).Enabled = false;
        }
       // Add more of your customization here.
       
    }
    
