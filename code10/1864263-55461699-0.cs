    public static class ActionExtension {
        public static void _ (this Action f) {
            if (f != null) f();
        }
    }
