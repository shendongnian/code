            var node = new Node
            {
                Children = new Dictionary<string, Node>
                {
                    { "a1", new Node
                        {
                            Children = new Dictionary<string, Node>
                            {
                                { "b1a", new Node { Value = 1 } },
                                { "b1b", new Node { Value = 2 } }
                            }
                        }
                    },
                    { "a2", new Node
                        {
                            Children = new Dictionary<string, Node>
                            {
                                { "b2a", new Node { Value = 3 } },
                                { "b2b", new Node { Value = 4 } }
                            }
                        }
                    }
                }
            };
            int y = node["a1"]["b1a"].Value;
            Assert.AreEqual(1, y);
