    [Test]
    public void GoodConnectionRaisesConnectionChangedEvent()
    {
        const int EXPECTED = 1;
        List<ConnectionChangedEventArgs> ev = new List<ConnectionChangedEventArgs>();
    
        // Mocks and setup stuff here...
    
        using (PlcController pc = new PlcController(mock.Object))
        {
            pc.ConnectionChanged += delegate(object sender, ConnectionChangedEventArgs e)
            {
                ev.Add(e);
            };
    
            pc.Connect();
        }
    
        Assert.That(ev.Count, Is.EqualTo(EXPECTED));
    }
