    public static void Run ( Action<float, EffectResult> action )
    {
        worker.DoWork += ( sender, e ) =>
        {
            foreach ( var effect in GlobalGraph.Effects )
            {
                var result = image.Apply (effect);
    
                action (100 * ( index / count ), result );
            }
        }
    };
