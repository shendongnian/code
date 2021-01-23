    public void Render(HtmlTextWriter writer)
    {
    	if (this._bag.Count > 0)
    	{
    		IDictionaryEnumerator enumerator = this._bag.GetEnumerator();
    		while (enumerator.MoveNext())
    		{
    			StateItem stateItem = enumerator.Value as StateItem;
    			if (stateItem != null)
    			{
    				string text = stateItem.Value as string;
    				string text2 = enumerator.Key as string;
    				if (text2 != null && text != null)
    				{
    					writer.WriteAttribute(text2, text, true);
    				}
    			}
    		}
    	}
    }
