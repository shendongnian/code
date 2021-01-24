    		[Route("api/Values/Table/Field/id")]
        public dynamic Get(string Table, string Field, string id)
        {
            GenericController generic = new GenericController();
            dynamic d = generic.Get(Table, Field, id);
            return d;
        }
