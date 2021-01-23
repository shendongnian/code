         ContextMenu contextMenu = 
            new System.Windows.Forms.ContextMenu (
               new [] {
                 new MenuItem ("Entry1", ContextMenuItem_Click),
                 new MenuItem ("Copy", ContextMenuItem_Click)
               });
         RichTextBox rtb = 
           new RichTextBox
             {
                Size = ClientSize,
                Parent = this,
                ContextMenu = contextMenu
             };
