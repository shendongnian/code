         public List<int> GetOrder() {
            CreateParentChildList();
            var tail = parentChildList.First(x => x.ChildId == null);
            int id = tail.Id;
            List<int> res = new List<int>() { tail.Id };
            while(true){
                var temp = parentChildList.FirstOrDefault(x => x.ChildId == id);
                if (temp == null)
                    break;
                res.Add(temp.Id);
                id = temp.Id;
            }
            return res;
        }
        public List<int> GetRecursiveParentIds(int id) {
            var order = GetOrder();
            order.Reverse();
            var res = order.TakeWhile(x => x != id);
            res = res.Reverse();
            return res.ToList();
        }
        public List<int> GetRecursiveChildIds(int id) {
            var order = GetOrder().TakeWhile(x => x != id);
            var res = order.Reverse();
            return res.ToList();
        }
