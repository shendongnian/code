        [Serializable]
        public class C : IDictionary<int,A>
        {
            private Dictionary<int,A> _inner = new Dictionary<int,A>;
            // implement interface ...
        }
