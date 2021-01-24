public ExecutionResult GetExecutionResult(Variant model) {
            var executionResult = new ExecutionResult();
            executionResult.Name = model.VariantName;
            var aggregateResults = new List<AggregateStats>();
            for(int counter = 0; counter < model.Subvariants.Count - 1; counter++) {
                var left = model.Subvariants[counter];
                var right = model.Subvariants[counter + 1];
                try {
                    using(var t = new AggregateCalculator(model)) {
                        for(int i = 0; i < 2; i++) {
                            if(i == 0) {
                                t.Start(i);
                                if(counter == 0) {
                                    aggregateResults.Add(new AggregateStats {
                                        Name = left.Name,
                                        //other properties
                                    });
                                }
                            }
                            else {
                                t.Start(i);
                                aggregateResults.Add(new AggregateStats {
                                    Name = right.Name,
                                    //other properties
                                });
                            }
                        }
                    }
                }
                catch(Exception ex) {
                    aggregateResults.Add(new AggregateStats {
                        Name = left.Name,
                        //other error props
                    });
                }
            }
            //changed this because I think this is what you meant, previously it didn't make any sense since you weren't assigning anything to executionResult
            executionResult.AggregateResults = aggregateResults.AsReadOnly();
            return executionResult;
        }
