    // inside type: Foo
    [OnDeserialized]
    public void OnDeserialized(StreamingContext ctx) {
        if(ctx != null) {
            Bar bar = ctx.Context as Bar;
            if(bar != null) this.Bar = bar; 
        }
    }
