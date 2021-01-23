    List<Point> sortedList = MyList.Sort(
        delegate(Point p1, Point p2) 
        {
            int r = p1.x.CompareTo(p2.x); 
            if(r.Equals(0)) return p1.y.CompareTo(p2.y);
            else return r;
        }
    );
