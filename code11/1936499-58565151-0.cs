    public class Condition<T> {
        public string[] Values;
        public Func<T, int> Test;
    
        public Condition(string[] values, Func<T, int> test) {
            Values = values;
            Test = test;
        }
    }
    
    public class Level {
        public static Level<T> MakeTree<T>(IEnumerable<T> src, Condition<T>[] conditions) => new Level<T>(src, conditions);
        public static IEnumerable<int> MakeKey<T>(Condition<T>[] conditions, params string[] values) {
            for (int depth = 0; depth < values.Length; ++depth)
                yield return conditions[depth].Values.IndexOf(values[depth]);
        }
    }
    
    public class Level<T> {
        public string Value;
        public Level<T>[] NextLevels;
        public List<T> Members;
    
        public Level(string value, List<T> members) {
            Value = value;
            Members = members;
            NextLevels = null;
        }
    
        public Level(IEnumerable<T> src, Condition<T>[] conditions) : this("ALL", src.ToList()) => GroupOneLevel(this, 0, conditions);
    
        public void GroupOneLevel(Level<T> parent, int depth, Condition<T>[] conditions) {
            var condition = conditions[depth];
            var nextLevels = new Level<T>[condition.Values.Length];
            for (int j2 = 0; j2 < condition.Values.Length; ++j2) {
                nextLevels[j2] = new Level<T>(condition.Values[j2], new List<T>());
            }
    
            for (int j2 = 0; j2 < parent.Members.Count; ++j2) {
                var member = parent.Members[j2];
                nextLevels[condition.Test(member)].Members.Add(member);
            }
            parent.NextLevels = nextLevels;
            if (depth + 1 < conditions.Length)
                for (int j3 = 0; j3 < condition.Values.Length; ++j3)
                    GroupOneLevel(nextLevels[j3], depth + 1, conditions);
        }
    
        public List<T> MembersForKey(IEnumerable<int> values) {
            var curLevel = this;
            foreach (var value in values)
                curLevel = curLevel.NextLevels[value];
    
            return curLevel.Members;
        }
    }
    
