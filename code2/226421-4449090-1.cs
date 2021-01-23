    public TableA GetById(int tableAId)
    {
        return _dataContext.TableA
            .Include("TableB.TableC") // use dot-notation to specify depth in the object graph
            .SingleOrDefault(ta => ta.TableAId == tableAId);
    }
