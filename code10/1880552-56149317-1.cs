        [HttpPost]
    [AutoValidateAntiforgeryToken]
            public IActionResult OnPostContextFreeGrammarPartial([FromBody]ContextFreeGrammarModel item) 
            {
                var grammarModel = new ContextFreeGrammarModel();
        
                return new PartialViewResult() {
                    ViewName = "_ContextFreeGrammar",
                    ViewData = new ViewDataDictionary<ContextFreeGrammarModel>(ViewData, grammarModel)
                };
            }
