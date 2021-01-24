    [HttpPost]
        public IActionResult Foo([ModelBinder(BinderType = typeof(DictionaryModelBinder))]Dictionary<string, object> things)
        {
            // the stuff you want
        }
