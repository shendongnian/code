     public partial class MyDataGridView : DataGridView
        {
           protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
              {
    			
    			if ( keyData == Keys.Tab ||  keyData == Keys.Enter )
    				return true;
    
    			return base.ProcessCmdKey( ref msg, keyData );
    		}
        }
