    [Test]
            public void PerformSanityCheck()
            {
                foreach (var s in NHHelper.Instance.GetConfig().ClassMappings)
                {
                    Console.WriteLine(" *************** " + s.MappedClass.Name);
                    
                        NHHelper.Instance.CurrentSession.CreateQuery(string.Format("from {0} e", s.MappedClass.Name))
                            .SetFirstResult(0).SetMaxResults(50).List();
                    
                }
            }
