    public class CustomGoRectangle : GoRectangle, IDisposable
    {
    	private DispositionWrapper<Pen> _ownedPen;
    
    	public override Pen Pen
    	{
    		get
    		{
    			return this._ownedPen.Instance;
    		}
    
    		set
    		{
    			if (value == null)
    			{
    				this.OwnedPen = null;
    			}
    			else
    			{
    				this.OwnedPen = new DispositionWrapper<Pen>(value, false);
    			}
    		}
    	}
    
    	private DispositionWrapper<Pen> OwnedPen
    	{
    		get
    		{
    			return this._ownedPen;
    		}
    
    		set
    		{
    			if (this._ownedPen != null)
    			{
    				this._ownedPen.Dispose();
    			}
    
    			this._ownedPen = value;
    		}
    	}
    
    
    	public void DoStuff()
    	{
    		this.OwnedPen = new DispositionWrapper<Pen>(new Pen(Color.Red, 4.0f), true);
    	}
    
    	public void DoOtherStuff()
    	{
    		this.OwnedPen = new DispositionWrapper<Pen>(new Pen(Color.Blue, 4.0f), true);
    	}
    
    	public void Test()
    	{
    		this.OwnedPen = new DispositionWrapper<Pen>(Pens.Green, false);
    		this.DoStuff();
    		this.DoOtherStuff();
    	}
    
    	public void Dispose()
    	{
    		if (this.OwnedPen != null)
    		{
    			this.OwnedPen.Dispose();
    		}
    	}
    }
