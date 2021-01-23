            // Phrase query
            PhraseQuery phraseQuery = new PhraseQuery();
            phraseQuery.Add(new Term("MyField", "A"));
            phraseQuery.Add(new Term("MyField", "Level"));
            // Or query
            BooleanQuery orQuery = new BooleanQuery();
            orQuery.Add(new BooleanClause(new TermQuery(new Term("MyField", "English")), BooleanClause.Occur.SHOULD));
            orQuery.Add(new BooleanClause(new TermQuery(new Term("MyField", "Maths")), BooleanClause.Occur.SHOULD));
            orQuery.Add(new BooleanClause(new TermQuery(new Term("MyField", "Physics")), BooleanClause.Occur.SHOULD));
            // Main query
            BooleanQuery query = new BooleanQuery();
            query.Add(phraseQuery, BooleanClause.Occur.MUST);
            query.Add(orQuery, BooleanClause.Occur.MUST);
