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
    
    
            public virtual IReadOnlyList<SubTest> SubTests
            {
                get
                {
                    if (_subTests == null)
                        _subTests = new List<SubTest>();
    
                    return _subTests.AsReadOnly();
                }
            }
    
    
            
    
    		public void RemoveSubTest( SubTest SubTest )
    		{
    			if( _subTests == null ) 
    				return;
    			
    			_subTests.Remove( SubTest );			
    		}
    
    	}
