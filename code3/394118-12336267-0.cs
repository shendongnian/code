    public partial class MainForm : Form
	{
		
		Undoer undoer;
		
		public MainForm()
		{
			InitializeComponent();
			
			this.txtBox.TextChanged += new EventHandler( TextBoxTextChanged );
			this.undoer = new Undoer(ref this.txtText);
			// create a context menu
			ContextMenu menu = new ContextMenu();
			menu.MenuItems.AddRange( new MenuItem[] { 
                        new MenuItem("&Undo",  new EventHandler( this.undoer.undo_Click  )),
                        new MenuItem("&Redo",  new EventHandler( this.undoer.redo_Click  ))
			});
			this.txtBox.ContextMenu = menu;
			// or create keypress event 
			this.txtBox.KeyDown += new KeyEventHandler( textBox_KeyDown );
			this.KeyDown  += new KeyEventHandler( textBox_KeyDown );
		}
		protected void TextBoxTextChanged(object sender, EventArgs e)
		{
			undoer.Save();
		}
		protected void textBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
			if (e.Modifiers == (System.Windows.Forms.Keys.Control))
			{
				if ( e.KeyCode == Keys.Z )
				{
					this.undoer.Undo();
					e.Handled = true;
				}
				if ( e.KeyCode == Keys.Y )
				{
					this.undoer.Redo();
					e.Handled = true;
				}
			}
		}
	}
-------
    public class Undoer
	{
		protected System.Windows.Forms.RichTextBox txtBox;
		protected List<string> LastData = new List<string>();
		protected int  undoCount = 0;
		
		protected bool undoing   = false;
		protected bool redoing   = false;
		
		
		public Undoer(ref System.Windows.Forms.RichTextBox txtBox)
		{
			this.txtBox = txtBox;
			LastData.Add(txtBox.Text);
		}
		
		public void undo_Click(object sender, EventArgs e)
		{
			this.Undo();
		}
		public void redo_Click(object sender, EventArgs e)
		{
			this.Redo();
		}
		public void Undo()
		{
			try
			{
				undoing = true;
				++undoCount;
				txtBox.Text = LastData[LastData.Count - undoCount - 1];
			}
			catch { }
			finally{ this.undoing = false; }
		}
		public void Redo()
		{
			try
			{
				if (undoCount == 0)
					return;
				
				redoing = true;
				--undoCount;
				txtBox.Text = LastData[LastData.Count - undoCount - 1];
			}
			catch { }
			finally{ this.redoing = false; }
		}
	
		public void Save()
		{
			if (undoing || redoing)
				return;
			
			if (LastData[LastData.Count - 1] == txtBox.Text)
				return;
			
			LastData.Add(txtBox.Text);
			undoCount = 0;
		}
	}
