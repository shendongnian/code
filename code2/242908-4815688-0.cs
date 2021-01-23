    class MyButton : Button
    {
        private Type m_TYpe;
    
        private object m_Object;
    
        public object Object
        {
            get { return m_Object; }
            set { m_Object = value; }
        }
        
        public Type TYpe
        {
            get { return m_TYpe; }
            set { m_TYpe = value; }
        }
    }
 
    Button1Click(object sender, EventArgs args)
    {
      MyButton mb = (sender as MyButton);
            
      //then you can access Mb.Type
      //and  Mb.object
    }
    
