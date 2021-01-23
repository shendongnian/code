    public class Test
        {
    
            private IList<SubTest>		_subTests;
    		
    
            public virtual void AddSubTest(SubTest SubTest)
            {
                if (_subTests == null)
                    _subTests = new List<SubTest>();
    
                _subTests.Add(SubTest);
    
                return this;
            }
    
    
            public virtual ReadOnlyCollection<SubTest> SubTests
            {
                get
                {
                    if (_subTests == null)
                        _subTests = new List<SubTest>();
    
                    return new ReadOnlyCollection<SubTest>(_subTests);
                }
            }
    
    
            
    
    		public void RemoveSubTest( SubTest SubTest )
    		{
    			if( _subTests == null ) 
    				return;
    			
    			_subTests.Remove( SubTest );			
    		}
    
    	}
