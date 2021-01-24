       public class PositionedEntity : Entity
       {
           protected int m_x;
           protected int m_y;
           protected int m_oldX;
           protected int m_oldY;
           
           public PositionedEntity(int x, int y, int w, int h, string image)
               : base(w, h, image)
           {
               m_x = x;
               m_y = y;
               m_oldX = x;
               m_oldY = y;
           }
           public virtual void move() { }
           public virtual void RestorePrevious() 
           {
               m_x = m_oldX;
               m_y = m_oldY;          
           }
           public int x
           {
               get
               {
                   return m_x;
               }
               set
               {
                   m_oldX = m_x;
                   m_x = value;
               }
           }
           public int y
           {
               get
               {
                   return m_y;
               }
               set
               {
                   m_oldY = m_y;
                   m_y = value;
               }
           }
       }
    
