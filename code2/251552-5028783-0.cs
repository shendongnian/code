     var TheActualChoiceIsIrrelevantForThisExample = new Choice();
                var Ditto = new Choice();
    
                var userChoices = new List<UserChoice>
                    {
                        new UserChoice("2000", 1, TheActualChoiceIsIrrelevantForThisExample ),
                        new UserChoice("2000", 2, Ditto ),
                        new UserChoice("2000", 3, Ditto ),
                        new UserChoice("1999", 1, Ditto ),
                        new UserChoice("1999", 2, Ditto ),
                        new UserChoice("1999", 3, Ditto ),
                        new UserChoice("2001", 1, Ditto ),
                        new UserChoice("2001", 2, Ditto ),
                        new UserChoice("2001", 3, Ditto ),
                    };
    
                
                var userChoicesGroupedById =
                    from userChoice in userChoices
                    group userChoice by userChoice.UserId;
    
                /*using List of LinkedListNode allows linq queries to access the nodes' previous and next properties. 
                 * if a linkedlist was used, then these properties would not be accessible (because we would be querying UserChoice objects, not LinkedListNodes)
                 */
                var linkedUserChoices = new List<LinkedListNode<UserChoice>>();
    
                foreach (var grp in userChoicesGroupedById)
                {
                    var userChoicesSortedByYear =new LinkedList<UserChoice>( grp.OrderBy(userChoice=>userChoice.Year));
                    
                    var currentNode = userChoicesSortedByYear.First;
                    
                    while (currentNode != null)
                    {
                        linkedUserChoices.Add(currentNode);
    
                        currentNode = currentNode.Next;
                    } 
                }
    
                var userChoicesGroupedByYear =
                    (from userChoiceNode in linkedUserChoices
                    group userChoiceNode by userChoiceNode.Value.Year).ToList();
    
                var dictionary = userChoicesGroupedByYear.ToDictionary(group => group.Key, group => group.ToList());
