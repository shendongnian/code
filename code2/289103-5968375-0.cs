    public class MyControl : Control {
        public MyControl() {
           this.Rects = new ObservableCollection<Rect>();
           // TODO: attach to CollectionChanged to know when to invalidate visual
        }
        public ObservableCollection<Rect> Rects { get; private set; }
        protected override void OnRender(DrawingContext dc) {
            SolidColorBrush mySolidColorBrush  = new SolidColorBrush();
            mySolidColorBrush.Color = Colors.LimeGreen;
            Pen myPen = new Pen(Brushes.Blue, 10);
            foreach (Rect rect in this.Rects)
                dc.DrawRectangle(mySolidColorBrush, myPen, rect);
        }
    }
