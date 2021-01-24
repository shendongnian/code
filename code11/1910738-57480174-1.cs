    private class _SplitView
    {
        private object instance;
        private Type type;
        public _SplitView( object instance ) 
        {
            this.instance = instance;
            type = instance.GetType();
        }
        public object DragOver( EditorWindow child, Vector2 screenPoint ) 
        {
            var method = type.GetMethod( "DragOver", BindingFlags.Instance | BindingFlags.Public );
            return method.Invoke( instance, new object[] { child, screenPoint } );
        }
        public void PerformDrop( EditorWindow child, object dropInfo, Vector2 screenPoint ) 
        {
            var method = type.GetMethod( "PerformDrop", BindingFlags.Instance | BindingFlags.Public );
            method.Invoke( instance, new object[] { child, dropInfo, screenPoint } );
        }
        public Rect position
        {
            get 
            {
                var property = type.GetProperty("screenPosition", BindingFlags.Instance | BindingFlags.Public);
                return property.GetValue(instance, null);
            }
        }
    }
