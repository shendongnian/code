        private Grammar CreateTestGrammar()
        {
            // item
            Choices item = new Choices();
            SemanticResultValue itemSRV;
            itemSRV = new SemanticResultValue("I E", "explorer");
            item.Add(itemSRV);
            itemSRV = new SemanticResultValue("explorer", "explorer");
            item.Add(itemSRV);
            itemSRV = new SemanticResultValue("firefox", "firefox");
            item.Add(itemSRV);
            itemSRV = new SemanticResultValue("mozilla", "firefox");
            item.Add(itemSRV);
            itemSRV = new SemanticResultValue("chrome", "chrome");
            item.Add(itemSRV);
            itemSRV = new SemanticResultValue("google chrome", "chrome");
            item.Add(itemSRV);
            SemanticResultKey itemSemKey = new SemanticResultKey("item", item);
            //build the permutations of choices...
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(itemSemKey);
            //now build the complete pattern...
            GrammarBuilder itemRequest = new GrammarBuilder();
            //pre-amble "[I'd like] a"
            itemRequest.Append(new Choices("Can you open", "Open", "Please open"));
            itemRequest.Append(gb);
            Grammar TestGrammar = new Grammar(itemRequest);
            return TestGrammar;
        }
