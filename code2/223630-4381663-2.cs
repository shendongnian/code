    Node root = new Node
            {
                operation = Operation.Or,
                children = new Node[]
                {
                    new Node
                    {
                        operation = Operation.And,
                        children = new Node[]
                        {
                              new Node{ element = "a" },
                              new Node{ element="b" }
                        }
                    },
                    new Node
                    {
                        children = new Node[]
                        {
                            new Node{ element = "c"},
                            new Node
                            {
                                operation= Operation.Or,
                                children = new Node[]
                                {
                                    new Node{ element= "d"},
                                    new Node{element = "e"}
                                }
                            }
                        }
                    }
                }
            };
