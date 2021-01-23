    private IList<CormantRadPane> _regeneratedPanes;
    private IList<CormantRadDockZone> _regeneratedDockZones;
    	
        public IList<CormantRadPane>  RegeneratedPanes
        {
        	get
        	{
        	if(_regeneratedPanes == null)
        			{
        				_regeneratedPanes = new List<CormantRadPane>()
        			}
        			
        			return _regeneratedPanes
        		}
        	}
        	
        	public IList<CormantRadDockZone> RegeneratedDockZones
        	{
        		get
        		{
        			if(_regeneratedDockZones == null)
        			{
        				_regeneratedDockZones = new List<CormantRadDockZone>()
        			}
        			
        			return _regeneratedDockZones
        		}
        	}
