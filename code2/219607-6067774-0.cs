        public IEnumerable<Foo> Search(string param)
        {
            Expression<Func<Foo, bool>> shortCircuit = a => true;
            Expression<Func<Foo, bool>> normal = a => a.Something == param;
            var filteredFoos = _fooRepository.GetAllByFilter(
                string.IsNullOrEmpty(param) ? shortCircuit : normal);
            return filteredFoos.ToList(); // no more exception.
        }
