        public class Expressions_BO<TObj, TBase>
        {
            public Expression<Func<TObj, bool>> Child_Predicate { get; set; }
            public Expression<Func<TObj, decimal>> Child_Key { get; set; }
            public Expression<Func<TBase, bool>> Base_Predicate { get; set; }
            public Expression<Func<TBase, decimal>> Base_DS_Key { get; set; }
        }
