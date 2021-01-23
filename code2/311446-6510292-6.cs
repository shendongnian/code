    private Stack<Image> _undoStack = new Stack<Image>();
    private Stack<Image> _redoStack = new Stack<Image>();
    
    private readonly object _undoRedoLocker = new object();
    
    private void Undo()
    {
        lock (_undoRedoLocker)
        {
            if (_undoStack.Count > 0)
            {
                _redoStack.Push(_undoStack.Pop());
                //OnUndo();
                pictureBox1.Image = _redoStack.Peek();
                pictureBox1.Refresh();
            }
        }
    }
    
    private void Redo()
    {
        lock (_undoRedoLocker)
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push(_redoStack.Pop());
                //OnRedo();
                pictureBox1.Image = _undoStack.Peek();
                pictureBox1.Refresh();
            }
        } 
    }
    
    //And whenever image need to be modified, add it to the undo stack first and then modify it
    private void UpdateImageData(Action updateImage)
    {
        lock (_undoRedoLocker)
        {
            _undoStack.Push(pictureBox1.Image);//image);
    
            try
            { 
                //manipulate the image here.
                updateImage();
            }
            catch
            {
                _undoStack.Pop();//because of exception remove the last added frame from stack
                throw;
            }
        }
    }
 
    private void pictureBox1_MouseClick(object sender, EventArgs e)
    {
        UpdateImageData(()=>
        {
                rect.Width = 0;
                rect.Height = 0;
                pictureBox1.Invalidate();
    
                int radius = 10; //Set the number of pixel you want to use here
                //Calculate the numbers based on radius
                int x0 = Math.Max(e.X - (radius / 2), 0),
                    y0 = Math.Max(e.Y - (radius / 2), 0),
                    x1 = Math.Min(e.X + (radius / 2), pictureBox1.Width),
                    y1 = Math.Min(e.Y + (radius / 2), pictureBox1.Height);
                Bitmap bm = pictureBox1.Image as Bitmap; //Get the bitmap (assuming it is stored that way)
                for (int ix = x0; ix < x1; ix++)
                {
                    for (int iy = y0; iy < y1; iy++)
                    {
                        bm.SetPixel(ix, iy, Color.Black); //Change the pixel color, maybe should be relative to bitmap
                    }
                }
                pictureBox1.Refresh(); //Force refresh
        }
    }
