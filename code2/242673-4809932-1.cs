    public SkinnedList() {
        this.AutoScroll = true;
        this.AutoScrollMinSize = new Size(0, 1000);
        this.Scroll += delegate { this.InvalidateEx(); };
    }
