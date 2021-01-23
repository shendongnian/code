    enum Action
    {
       None,
       Stop,
       CheckDestroy
    
    }
    class InterestingPoint
    {
      Point m_Point;
      Action m_Action;
    }
    
    class MovingImage
    {
     public bool DestroyMe {get; private set; }
  
     PictureBox m_PictureBox;
     List<InterestingPoint> m_PointsToVisit;
     int m_StoppedUntil = 0;
     MovingImage(...) 
    { 
       // Constructor
    }
     void Update(int k)
     {
       if(m_StoppedUntil > k) return;
       //Move m_PictureBox towards m_PointsToVisit.First
       //when m_PictureBox.Location == m_PointToVisit.First, check if the InterestingPoint
       //has a action you need to handle, 
       //like if the action is stop, you set m_StoppedUntil to k+ the number of frames you 
       //want the picturebox to stay still. (m_StoppedUntil = k+10 => doesnt update for 10 frames)
       //if the action is checkdestroy, see if it shall be destroyed and set DestroyMe to true
    }
