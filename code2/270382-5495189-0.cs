    Class MyWidget : IComparable
    {
        public int Piece { get; set; }
        public string Thing { get; set; }
        public MyWidget()
        {
            this.Piece = 1;
            this.Thing = "default";
        }
        public int CompareTo(object obj)
        {
            var otherWidget = obj as MyWidget;
            if (otherWidget != null)
            {
                return (this.Piece + this.Thing.Length).CompareTo(otherWidget.Piece + otherWidget.Thing.Length);
            }
            else
            {
                throw new ArgumentException("Object is not a MyWidget");
            }
        }
    }
