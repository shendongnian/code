    public static class CombinatorialExtensionMethods {
    	public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences) 
    	{ 
      		IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() }; 
      		return sequences.Aggregate( 
    			emptyProduct, 
    			(accumulator, sequence) =>  
    	  		from accseq in accumulator  
    	  		from item in sequence  
    	  		select accseq.Concat(new[] {item}));                
    	}
    
    	public static IEnumerable<IEnumerable<T>> CartesianPower<T>(this IEnumerable<T> sequence, int power) 
    	{ 
      		var sequences = Enumerable.Repeat<IEnumerable<T>>(sequence,power);
    		return sequences.CartesianProduct<T>();
    	}
    	
    	public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> seq, int k)
    	{ 
      		var sequences = Enumerable.Repeat<IEnumerable<T>>(seq,k);
    		IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() }; 
    		return sequences.Aggregate( 
    			emptyProduct, 
    			(accumulator, sequence) =>  
    	  		from accseq in accumulator  
    	  		from item in sequence
    			where !accseq.Contains(item)
    	  		select accseq.Concat(new[] {item}));
    	}
    
    	public static IEnumerable<IEnumerable<int>> Choose(this IEnumerable<int> seq, int k)
    	{ 
      		var sequences = Enumerable.Repeat<IEnumerable<int>>(seq,k);
    		IEnumerable<IEnumerable<int>> emptyProduct = new[] { Enumerable.Empty<int>() }; 
    		return sequences.Aggregate( 
    			emptyProduct, 
    			(accumulator, sequence) =>  
    	  		from accseq in accumulator  
    	  		from item in sequence
    			where accseq.All(accitem => accitem.CompareTo(item) < 0)
    	  		select accseq.Concat(new[] {item}));
    	}
    	
    	public static IEnumerable<IEnumerable<T>> Choose<T>(this IEnumerable<T> seq, int k)
    	{ 
    		IEnumerable<int> idxSequence = Enumerable.Range(0, seq.Count());
    		IEnumerable<IEnumerable<int>> idxChoose = idxSequence.Choose(k);
    		IEnumerable<IEnumerable<T>> result = Enumerable.Empty<IEnumerable<T>>(); 
    		foreach (IEnumerable<int> permutation in idxChoose)
    		{
    			IEnumerable<T> item = Enumerable.Empty<T>();
    			foreach (int index in permutation)
    			{
    				item = item.Concat(new[] { seq.ElementAt(index) });
    			}
    			result = result.Concat(new[] { item });
    		}
      		return result;
    	}
    	
    	public static IEnumerable<IEnumerable<T>> PowerSet<T>(this IEnumerable<T> seq)
    	{
    		IEnumerable<IEnumerable<T>> result = new[] { Enumerable.Empty<T>() };
    		for (int i=1; i<=seq.Count(); i++)
    		{
    			result = result.Concat(seq.Choose<T>(i));
    		}
    		
    		return result;
    	}
    }
