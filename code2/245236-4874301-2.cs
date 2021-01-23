    void timer_Tick(object sender, EventArgs e)
    {
      k++
      foreach(MovingImage m in m_MyMovingImages)
      {
        m.Update(k);
        if(m.DestroyMe) 
        {
          //Destroy it.
        }
      }
    }
