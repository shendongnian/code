    public static IEnumerable<EffectResult> GetSomeValues()
    {
    	// code to set up worker etc
    	worker.DoWork += ( sender, e ) =>
    	{
    		foreach ( var effect in GlobalGraph.Effects )
    		{
    			// Returns EffectResult
    			yield return image.Apply (effect);
    		}
    	};
    }
