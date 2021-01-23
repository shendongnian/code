    [Test]
    public void Checked()
    {
        byte i = 0xff;
        i = (byte) (i + 1);
    }
    
     
    [Test]
    public void UnChecked()
    {
        int i = 0x7fffffff;
        i++;
    }
