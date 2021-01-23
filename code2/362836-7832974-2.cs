    [Test]
    public void Checked()
    {
        checked
        {
            byte i = 255;
            i++;
        }
    }
    
    [Test]
    public void UnChecked()
    {
        unchecked
        {
            int i = Int32.MaxValue;
            i = i + 1;
        }
    }
