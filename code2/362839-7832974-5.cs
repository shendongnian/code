    [Test]
    public void Checked()
    {
        checked
        {
            int i = int.MaxValue;
            i = i * 100;
            Debug.WriteLine(i);
        }
    }
    
    [Test]
    public void UnChecked()
    {
        unchecked
        {
            int i = int.MaxValue;
            i = i * 100;
            Debug.WriteLine(i);
        }            
    }
