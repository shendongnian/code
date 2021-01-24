    public class Moving
    {
        public bool startedmoving = false;
    
        public void move()
        {
            EventHandler moved = Moved;
    
            startedmoving = true;
    
            if (moved != null)        
               moved.Invoke(this, EventArgs.Empty);
        }
    
        public event EventHandler Moved;
    }
    
    ...
    
    public class Check  
    { 
        private Moving m_Moving;
        private void onMoving(Object sender, EventArgs e) 
        {
            // Will be executed on every m_Moving.move() call     
        }
        public Check() 
        {
            m_Moving = new Moving();
            m_Moving.Moved += onMoving;
        } 
    }
