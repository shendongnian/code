        public IQueryable SomeFunc()
        {
            IQueryable result = Repo.SomeLinqQuery();
            if (result.GetEnumerator().MoveNext() == false)
            {
                throw new Exception("Results empty");
            }
            return result;
        }
