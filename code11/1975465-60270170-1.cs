    void Main()
    {
        List<SampleItem> itemsWithCycle = new List<SampleItem>
        {
            new SampleItem{ ParentId=null, ChildId=1 },
            new SampleItem{ ParentId=1, ChildId=2 },
            new SampleItem{ ParentId=2, ChildId=4 },
            new SampleItem{ ParentId=4, ChildId=1 }
        };
        List<SampleItem> itemsWithoutCycle = new List<SampleItem>
        {
            new SampleItem{ ParentId=null, ChildId=1 },
            new SampleItem{ ParentId=1, ChildId=2 },
            new SampleItem{ ParentId=2, ChildId=4 },
            new SampleItem{ ParentId=4, ChildId=5 }
        };
    
        Console.WriteLine(HasCycle(itemsWithCycle)); // true
        Console.WriteLine(HasCycle(itemsWithoutCycle)); // false
        
        
        bool HasCycle(IEnumerable<SampleItem> items) {
            var slow = items.FirstOrDefault(i => i.ParentId == null);
            var fast = slow;
        
            while(fast != null) {
                fast = Next(Next(fast));
                slow = Next(slow);
                
                if(fast == slow) return true;
            }
            return false;
            
            SampleItem Next(SampleItem item)
            {
                if(item == null) return null;
                
                return items.FirstOrDefault(i => i.ParentId == item.ChildId);
            }
        }
    }
