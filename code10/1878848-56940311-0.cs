    public static Mock<DbQuery<TQuery>> CreateDbQueryMock<TQuery>(this DbQuery<TQuery> dbQuery, IEnumerable<TQuery> sequence) where TQuery : class {
    	var dbQueryMock = new Mock<DbQuery<TQuery>>();
    
    	var queryableSequence = sequence.AsQueryable();
    
    	dbQueryMock.As<IAsyncEnumerableAccessor<TQuery>>().Setup(m => m.AsyncEnumerable).Returns(queryableSequence.ToAsyncEnumerable);
    	dbQueryMock.As<IQueryable<TQuery>>().Setup(m => m.ElementType).Returns(queryableSequence.ElementType);
    	dbQueryMock.As<IQueryable<TQuery>>().Setup(m => m.Expression).Returns(queryableSequence.Expression);
    	dbQueryMock.As<IEnumerable>().Setup(m => m.GetEnumerator()).Returns(queryableSequence.GetEnumerator());
    	dbQueryMock.As<IEnumerable<TQuery>>().Setup(m => m.GetEnumerator()).Returns(queryableSequence.GetEnumerator());	
    	dbQueryMock.As<IQueryable<TQuery>>().Setup(m => m.Provider).Returns(queryableSequence.Provider);
    
    	return dbQueryMock;
    }
