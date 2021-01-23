    private Grammar CreatePizzaGrammar()
    {
        //create the pizza grammar
        GrammarBuilder pizzaRequest = CreatePizzaGrammarBuilder();
        Grammar pizzaGrammar = new Grammar(pizzaRequest);
        return pizzaGrammar;
    }
    private GrammarBuilder CreatePizzaGrammarBuilder()
    {
        // this is adapted from the sample in http://msdn.microsoft.com/en-us/magazine/cc163663.aspx
        // but the API changed before Vista was released so some changes were made.
        //[I'd like] a [<size>] [<crust>] [<topping>] pizza [please]
        //build the core set of choices
        // size
        Choices sizes = new Choices();
        SemanticResultValue sizeSRV;
        sizeSRV = new SemanticResultValue("small", "small");
        sizes.Add(sizeSRV);
        sizeSRV = new SemanticResultValue("regular", "regular");
        sizes.Add(sizeSRV);
        sizeSRV = new SemanticResultValue("medium", "regular");
        sizes.Add(sizeSRV);
        sizeSRV = new SemanticResultValue("large", "large");
        sizes.Add(sizeSRV);
        SemanticResultKey sizeSemKey = new SemanticResultKey("size", sizes);
        // crust
        Choices crusts = new Choices();
        SemanticResultValue crustSRV;
        crustSRV = new SemanticResultValue("thin crust", "thin crust");
        crusts.Add(crustSRV);
        crustSRV = new SemanticResultValue("thin", "thin crust");
        crusts.Add(crustSRV);
        crustSRV = new SemanticResultValue("thick crust", "thick crust");
        crusts.Add(crustSRV);
        crustSRV = new SemanticResultValue("thick", "thick crust");
        crusts.Add(crustSRV);
        SemanticResultKey crustSemKey = new SemanticResultKey("crust", crusts);
        // toppings
        Choices toppings = new Choices();
        SemanticResultValue toppingSRV;
        toppingSRV = new SemanticResultValue("vegetarian", "vegetarian");
        toppings.Add(toppingSRV);
        toppingSRV = new SemanticResultValue("veggie", "vegetarian");
        toppings.Add(toppingSRV);
        toppingSRV = new SemanticResultValue("pepperoni", "pepperoni");
        toppings.Add(toppingSRV);
        toppingSRV = new SemanticResultValue("cheese", "cheese");
        toppings.Add(toppingSRV);
        toppingSRV = new SemanticResultValue("plain", "cheese");
        toppings.Add(toppingSRV);
        SemanticResultKey toppingSemKey = new SemanticResultKey("topping", toppings);
        //build the permutations of choices...
        // 1. choose all three
        GrammarBuilder sizeCrustTopping = new GrammarBuilder();
        sizeCrustTopping.Append(sizeSemKey);
        sizeCrustTopping.Append(crustSemKey);
        sizeCrustTopping.Append(toppingSemKey);
        // 2. choose size and topping
        GrammarBuilder sizeAndTopping = new GrammarBuilder();
        sizeAndTopping.Append(sizeSemKey);
        sizeAndTopping.Append(toppingSemKey);
        // sizeAndTopping.Append(new SemanticResultKey("crust", "thick crust"));
        // sizeAndTopping.AppendResultKeyValue("crust", "thick crust");
        // 3. choose size and crust, and assume cheese
        GrammarBuilder sizeAndCrust = new GrammarBuilder();
        sizeAndCrust.Append(sizeSemKey);
        sizeAndCrust.Append(crustSemKey);
        // 4. choose topping and crust, and assume cheese
        GrammarBuilder toppingAndCrust = new GrammarBuilder();
        toppingAndCrust.Append(crustSemKey);
        toppingAndCrust.Append(toppingSemKey);
        // 5. choose topping only, and assume the rest
        GrammarBuilder toppingOnly = new GrammarBuilder();
        toppingOnly.Append(toppingSemKey);         //, "topping");
        // 6. choose size only, and assume the rest
        GrammarBuilder sizeOnly = new GrammarBuilder();
        sizeOnly.Append(sizeSemKey);
        // 7. choose crust only, and assume the rest
        GrammarBuilder crustOnly = new GrammarBuilder();
        crustOnly.Append(crustSemKey);
        //assemble the permutations             
        Choices permutations = new Choices();
        permutations.Add(sizeCrustTopping);
        permutations.Add(sizeAndTopping);
        permutations.Add(sizeAndCrust);
        permutations.Add(toppingAndCrust);
        permutations.Add(toppingOnly);
        permutations.Add(sizeOnly);
        permutations.Add(crustOnly);
        GrammarBuilder permutationList = new GrammarBuilder();
        permutationList.Append(permutations);
        //now build the complete pattern...
        GrammarBuilder pizzaRequest = new GrammarBuilder();
        //pre-amble "[I'd like] a"
        pizzaRequest.Append(new Choices("I'd like a", "a", "I need a", "I want a"));
        //permutations "[<size>] [<crust>] [<topping>]"
        pizzaRequest.Append(permutationList, 0, 1);
        //post-amble "pizza [please]"
        pizzaRequest.Append(new Choices("pizza", "pizza please", "pie", "pizza pie"));
        return pizzaRequest;
    }
