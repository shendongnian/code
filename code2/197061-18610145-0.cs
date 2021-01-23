      public override IQueryable<Image> FindAll(System.Linq.Expressions.Expression<Func<Image, dynamic>> Id)
            {
                dynamic currentType = Id.Parameters[0];
                var id = currentType.Type.GUID;
                var result = (_uniwOfWork as UnitOfWork).uspGetImages(id.ToString());
                return FindAll();
            }
