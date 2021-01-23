      var join = from d in GetDepts()
                 from e in db1.Emps
                 select new {
                   e.ENAME,
                   d.DNAME
                 };
      join.ToList();
    }
    public IEnumerable<DEPT> GetDepts() {
      return db.DEPTs.AsQueryable();
    }
