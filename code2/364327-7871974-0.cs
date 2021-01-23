    dataGridView1.EditingControlShowing += (senderObject,eventArgs)=>
      {
        eventArgs.Control.PreviewKeyDown += (sa, ea) =>
          {
           if (ea.KeyCode == Keys.Return)
             {
               MessageBox.Show("Something...");
             }
          };
       };
