    public class DragDropManager
    {
        private UserControl _parent;
    
        private AddFilesEventHandler OnAddFiles;   
    
        public DragDropManager()
    	{
    	}
    
        public UserControl Parent
        {
            set
            {
                _parent = value;    
    
                if ( ! ( _parent is IDropFileTarget ) )
                {
                    throw new Exception("DragDropManager: Parent usercontrol does not implement IDropFileTarget interface");
                }
    
                OnAddFiles = new AddFilesEventHandler(((IDropFileTarget)_parent).AddFiles);
                _parent.AllowDrop = true;
                _parent.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
                _parent.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            }
        }
    
        /// <summary>
        /// Handle parent form DragEnter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] formats = e.Data.GetFormats(true);
    
            //e.Effect = DragDropEffects.All;
    
            for (int formatIndex = 0; formatIndex < formats.Length; formatIndex++)
            {
                switch (formats[formatIndex])
                {
                    case Consts.DragDropFormats.FileDrop:
                        e.Effect = DragDropEffects.Copy;
                        break;
                    case Consts.DragDropFormats.Text:
                        e.Effect = DragDropEffects.Move;
                        break;
                    case Consts.DragDropFormats.UniformResourceLocator:
                        e.Effect = DragDropEffects.Link;
                        break;
                }
            }
        }
    
        /// <summary>
        /// Handle parent form DragDrop event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            try
            {
                string[] formats = e.Data.GetFormats(true);
                string[] values = new string[1];
                string url = string.Empty;
    
                for (int formatIndex = 0; formatIndex < formats.Length; formatIndex++)
                {
                    switch (formats[formatIndex])
                    {
                        case Consts.DragDropFormats.FileDrop:
                            Array itemList = (Array)e.Data.GetData(Consts.DragDropFormats.FileDrop);
    
                            if (itemList != null)
                            {
                                _parent.BeginInvoke(OnAddFiles, new Object[] { itemList });
                                _parent.Focus();
                            }
                            break;
                        case Consts.DragDropFormats.Text:
                        case Consts.DragDropFormats.UniformResourceLocator:
                            values[0] = e.Data.GetData(Consts.DragDropFormats.Text).ToString();
                            _parent.BeginInvoke(OnAddFiles, new Object[] { values });
                            _parent.Focus();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error in DragDropManager.OnDragDrop function: " + ex.Message);
            }
        }
    
    }
