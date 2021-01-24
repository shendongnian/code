    public async Task<IEnumerable<dynamic>> GetFilteredRowsByID(int id)
    {
        return from m in _context.TableName
               where id != 0 ? m.id == id : true
               join ...
               join ...
               select new {...}
    }
