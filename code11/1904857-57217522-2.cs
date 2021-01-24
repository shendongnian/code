    // A - B
    var listAExceptB = listA.Except(listB, tableNameComparer);
    Assert.Collection(listAExceptB,
        x => Assert.Equal("Table B", x.TableName));
    
    // B - A
    var listBExceptA = listB.Except(listA, tableNameComparer);
    Assert.Collection(listBExceptA,
        x => Assert.Equal("Table C", x.TableName));
    
    // A ∩ B
    var listIntersect = listA.Intersect(listB, tableNameComparer);
    Assert.Collection(listIntersect,
        x => Assert.Equal("Table A", x.TableName));
    
    // A ∪ B
    var listUnion = listA.Union(listB, tableNameComparer);
    Assert.Collection(listUnion,
        x => Assert.Equal("Table A", x.TableName),
        x => Assert.Equal("Table B", x.TableName),
        x => Assert.Equal("Table C", x.TableName));
