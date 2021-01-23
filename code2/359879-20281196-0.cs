    private void vScrollBar1_Scroll(object sender, ScrollEventArgs e) {
        Debug.WriteLine(e.ScrollOrientation.ToString());
    
        if (e.Type == ScrollEventType.ThumbTrack) {
            if (e.NewValue > e.OldValue) {
                Debug.WriteLine("down");
            } else if (e.NewValue < e.OldValue) {
                Debug.WriteLine("up");
            } else {
                Debug.WriteLine("stay");
            }
        } else {
            Debug.WriteLine(e.Type.ToString());
        }
    }
