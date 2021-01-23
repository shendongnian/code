    private MockRepository m_mocks = new MockRepository();
    private IXGateManager xGateManager = m_mocks.DynamicMock<IXGateManager>();
    
    using (m_mocks.Record())
    {
    	xGateManager.SendXGateMessage(null, null);
    	LastCall.IgnoreArguments().Repeat.Once();
    }
    
    using (m_mocks.Playback())
    {
    	//... execute your test
    }
