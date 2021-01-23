    public static class Extensions {
    
        public static void Times(this int n, Action action) {
            if (action != null)
                for (int i = 0; i < n; ++i)
                    action();
        }
    }
