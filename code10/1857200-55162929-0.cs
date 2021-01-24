        private Dictionary<int, List<Object>> randoms=new Dictionary<int, List<Object>>();
        private List<Object> GetRandom(List<Object> objs,int? seed)
        {
            if (seed == null)
            {
                return objs.OrderBy(a => Guid.NewGuid()).ToList();
            }
            else
            {
                if (!randoms.ContainsKey(seed.Value))
                randoms[seed.Value] = objs.OrderBy(a => Guid.NewGuid()).ToList();
                return randoms[seed.Value];
            }
        }
