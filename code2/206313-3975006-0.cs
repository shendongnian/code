    class SaveDataEventArgs : EventArgs
    {
        public readonly string Data;
        public SaveDataEventArgs( string data )
        {
            Data = data;
        }
    }
    
    class ChildForm
    {
        public event EventHandler<SaveDataEventArgs> SaveData
    
        void button_Click( ... )
        {
            OnSaveData( new SaveDataEventArgs( textbox1.Text );
        }
    
        protected virtual void OnSaveData( SaveDataEventArgs e )
        {
            EventHandler<SaveDataEventArgs> del = SaveData;
            if( del != null )
            {
                SaveData( this, e );
            }
        }
    }
    
    class Form1 : Form
    {
        void ShowChildForm( )
        {
            using( ChildForm frm = new ChildForm() )
            {
                frm.SaveData += frm_SaveData;
                frm.ShowDialog();
            }
        }
    
        void frm_SaveData( object sender, SaveDataEventArgs e )
        {
            label1 = e.Data;  // data from the child form, do what you need to do with it
        }
    }
