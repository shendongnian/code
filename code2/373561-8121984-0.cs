		// We use a boolean query to combine all prefix queries
		var analyzer = new SimpleAnalyzer();
		var query = new BooleanQuery();
		using ( var reader = new StringReader( queryTerms ) )
		{
			// This is what we need to do in order to get the terms one by one, kind of messy but seemed to be the only way
			var tokenStream = analyzer.TokenStream( "why_do_I_need_this", reader );
			var termAttribute = tokenStream.GetAttribute( typeof( TermAttribute ) ) as TermAttribute;
			// This will return false when all tokens has been processed.
			while ( tokenStream.IncrementToken() )
			{
				var token = termAttribute.Term();
				query.Add( new PrefixQuery( new Term( KEYWORDS_FIELD_NAME, token ) ), BooleanClause.Occur.MUST );
			}
			// I don't know if this is necessary, but can't hurt
			tokenStream.Close();
		}
