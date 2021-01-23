    private double m_dCurZoom = 1.0;
    public double Zoom
    {
       get { return m_dCurZoom; }
       set
       {
          double oldzoom = m_dCurZoom;
          if (m_dCurZoom != value)
          {
             m_dCurZoom = value;
             OnPropertyChanged("Zoom");
             UpdateZoom(oldzoom);
          }
       }
    }
    private ScaleTransform m_transZoom;
    public ScaleTransform TransZoom
    {
       get { return m_transZoom; }
    }
    private TranslateTransform m_transPan;
    /// <summary>
    /// Gets or sets the Panning in X axis.
    /// </summary>
    public double PanX
    {
       get { return m_transPan.X; }
       set
       {
          if (m_transPan.X != value)
          {
             m_transPan.X = value;
             ResizeElementContents();
          }
       }
    }
      /// <summary>
      /// Gets or sets the Panning in Y axis.
      /// </summary>
      public double PanY
      {
         get { return m_transPan.Y; }
         set
         {
            if (m_transPan.Y != value)
            {
               m_transPan.Y = value;
               ResizeElementContents();
            }
         }
      }
