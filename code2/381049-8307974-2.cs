    public Edges DetectEdge(Rect A, Rect B) { 
       rectC = rectA.Intersect(rectB);
        if(rectC.IsEmpty) return Edges.None;
        Edge edge = Edges.Inside;
        if(rectA.X+rectA.Width == rectB.X){
         edge = Edges.Left;
        }
        if(rectA.Y+rectA.Height == rectB.Y){
         edge = edge | Edges.Top;
        }
        if(rectA.X  == rectC.X + rectB.Width){
         edge = edge | Edges.Right;
        }
        if(rectA.Y == rectB.Y + rectB.Heigth){
         edge = edge | Edges.Bottom;
        }
        return edge;
    }
